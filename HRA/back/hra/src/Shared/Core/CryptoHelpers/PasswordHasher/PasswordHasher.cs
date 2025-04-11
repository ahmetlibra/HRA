using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Core.CryptoHelpers.PasswordHasher
{
    public static class PasswordHasher
    {


        // --- Yapılandırma Değerleri ---

        // Salt boyutunu byte cinsinden belirler. 16 byte (128 bit) yaygın ve güvenli bir değerdir.
        private const int SaltSize = 16;

        // Hash boyutunu byte cinsinden belirler. SHA256 için 32 byte (256 bit).
        private const int HashSize = 32;

        // Tekrar sayısı. Bu değer ne kadar yüksek olursa, brute-force saldırılarına karşı o kadar dayanıklı olur,
        // ancak hash'leme ve doğrulama işlemi o kadar yavaşlar. Modern sistemler için 10000 iyi bir başlangıçtır.
        // ASP.NET Core Identity varsayılan olarak daha yüksek değerler kullanır (örn. .NET 6'da 10000, .NET 7+'da 600000).
        // Güvenlik ve performans dengesini uygulamanızın ihtiyacına göre ayarlayın.
        private const int Iterations = 600000; // .NET 7+ varsayılanına yakın bir değer

        // Kullanılacak hash algoritması. SHA256 veya SHA512 önerilir.
        private static readonly HashAlgorithmName _hashAlgorithmName = HashAlgorithmName.SHA256;

        // Salt ve Hash'i birleştirmek için kullanılacak ayraç karakteri.
        // Base64 formatında saklayacağımız için aslında doğrudan byte birleştirmesi yapacağız.
        // private const char Delimiter = ';'; // Bu yöntemi kullanmayacağız, byte birleştirme daha verimli.

        /// <summary>
        /// Verilen parolayı güvenli bir şekilde hash'ler (Salt + PBKDF2).
        /// </summary>
        /// <param name="password">Hash'lenecek düz metin parola.</param>
        /// <returns>Salt ve Hash'i içeren Base64 formatında bir string.</returns>
        /// <exception cref="ArgumentNullException">Parola null ise fırlatılır.</exception>
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password), "Parola boş veya null olamaz.");
            }

            // 1. Güvenli Rastgele Salt Oluştur
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);

            // 2. PBKDF2 ile Hash Oluştur
            // Rfc2898DeriveBytes(password, salt, iterations, hashAlgorithm)
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, _hashAlgorithmName);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            // 3. Salt ve Hash'i Birleştir
            // Önce salt, sonra hash olacak şekilde tek bir byte dizisi oluşturuyoruz.
            byte[] combinedBytes = new byte[SaltSize + HashSize];

            // Salt'ı başa kopyala
            Buffer.BlockCopy(salt, 0, combinedBytes, 0, SaltSize);

            // Hash'i salt'ın sonrasına kopyala
            Buffer.BlockCopy(hash, 0, combinedBytes, SaltSize, HashSize);

            // 4. Sonucu Base64 String olarak döndür (veritabanında saklamak için uygun format)
            return Convert.ToBase64String(combinedBytes);
        }

        /// <summary>
        /// Verilen bir parolanın, daha önce oluşturulmuş hash ile eşleşip eşleşmediğini doğrular.
        /// </summary>
        /// <param name="hashedPassword">HashPassword metodu ile oluşturulmuş, salt ve hash içeren Base64 string.</param>
        /// <param name="providedPassword">Doğrulanacak düz metin parola.</param>
        /// <returns>Parola eşleşirse true, aksi takdirde false.</returns>
        /// <exception cref="ArgumentNullException">Parametrelerden herhangi biri null ise fırlatılır.</exception>
        /// <exception cref="FormatException">hashedPassword geçerli bir Base64 string değilse veya beklenen formatta değilse.</exception>
        public static bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            if (string.IsNullOrEmpty(hashedPassword))
            {
                throw new ArgumentNullException(nameof(hashedPassword), "Hash'lenmiş parola boş veya null olamaz.");
            }
            if (string.IsNullOrEmpty(providedPassword))
            {
                throw new ArgumentNullException(nameof(providedPassword), "Sağlanan parola boş veya null olamaz.");
            }

            // 1. Base64 String'i Geri Byte Dizisine Çöz
            byte[] combinedBytes;
            try
            {
                combinedBytes = Convert.FromBase64String(hashedPassword);
            }
            catch (FormatException ex)
            {
                throw new FormatException("hashedPassword geçerli bir Base64 formatında değil.", ex);
            }


            // 2. Salt ve Hash'i Ayır
            // Gelen byte dizisinin boyutu beklenen boyutta mı kontrol et
            if (combinedBytes.Length != SaltSize + HashSize)
            {
                // Güvenlik notu: Burada direkt false dönmek, potansiyel saldırgana bilgi sızdırabilir.
                // Teorik olarak, tüm adımları yapıp sonda sahte bir karşılaştırma yapmak daha güvenli olabilir (timing attack önlemi).
                // Ancak bu implementasyonda basitlik için doğrudan kontrol yapıyoruz.
                // Daha sağlam sistemlerde sabit zamanlı karşılaştırma (constant-time comparison) düşünülmelidir.
                Console.Error.WriteLine($"Beklenmeyen hash formatı. Beklenen boyut: {SaltSize + HashSize}, Gelen boyut: {combinedBytes.Length}");
                return false; // Veya loglama yapıp false dön.
                              // throw new FormatException("Hash'lenmiş parolanın formatı beklenenden farklı.");
            }

            byte[] salt = new byte[SaltSize];
            Buffer.BlockCopy(combinedBytes, 0, salt, 0, SaltSize);

            byte[] storedHash = new byte[HashSize];
            Buffer.BlockCopy(combinedBytes, SaltSize, storedHash, 0, HashSize);

            // 3. Sağlanan Parolayı Aynı Salt ve Parametrelerle Hash'le
            var pbkdf2 = new Rfc2898DeriveBytes(providedPassword, salt, Iterations, _hashAlgorithmName);
            byte[] computedHash = pbkdf2.GetBytes(HashSize);

            // 4. Hesaplanan Hash ile Saklanan Hash'i Karşılaştır (Sabit Zamanlı Karşılaştırma Önemli!)
            // Timing attack'lara karşı savunmasız olmamak için tüm byte'ları karşılaştırmak önemlidir.
            // Basit `==` veya `SequenceEqual` yerine, byte byte karşılaştırma yapmak daha güvenlidir.
            return SlowEquals(storedHash, computedHash);
        }

        /// <summary>
        /// İki byte dizisini, işlem süresi içeriğe bağlı olmayacak şekilde karşılaştırır (Timing Attack'ları önlemeye yardımcı olur).
        /// </summary>
        /// <param name="a">Karşılaştırılacak ilk byte dizisi.</param>
        /// <param name="b">Karşılaştırılacak ikinci byte dizisi.</param>
        /// <returns>Diziler eşitse true, değilse false.</returns>
        private static bool SlowEquals(byte[] a, byte[] b)
        {
            // Farklı uzunluktaki diziler asla eşit olamaz.
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
            {
                // XOR işlemi: Eşitse 0, farklıysa 0'dan farklı bir değer üretir.
                // Tüm farkları OR (|) ile birleştiririz. Sonuçta diff 0 ise diziler eşittir.
                diff |= (uint)(a[i] ^ b[i]);
            }
            return diff == 0;
        }




    }
}
