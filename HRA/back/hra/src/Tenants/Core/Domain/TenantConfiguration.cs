using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TenantConfiguration
    {

        public Guid TenantId { get; set; }

        /// <summary>
        /// Uygulama arayüzünde kullanılacak tema rengi (örneğin: "#0078D4").
        /// </summary>
        public string ThemeColor { get; set; }

        /// <summary>
        /// Tenant'a özel logo URL'si (CDN'den alınabilir).
        /// </summary>
        public string LogoUrl { get; set; }

        /// <summary>
        /// Varsayılan dil ayarı (örn: "tr", "en").
        /// </summary>
        public string? Language { get; set; }

        /// <summary>
        /// Maaş bordrosu modülünün bu tenant için açık olup olmadığı.
        /// </summary>
        public bool EnablePayroll { get; set; }

        /// <summary>
        /// Bu tenant'ın sistemde oluşturabileceği maksimum kullanıcı sayısı.
        /// </summary>
        public int MaxUsers { get; set; }

        /// <summary>
        /// Kullandıkları abonelik planı (örn: "free", "standard", "enterprise").
        /// </summary>
        public string? Plan { get; set; }

        /// <summary>
        /// Tenant'a özel tarih formatı (örn: "dd.MM.yyyy", "MM/dd/yyyy").
        /// </summary>
        public string? DateFormat { get; set; }

        /// <summary>
        /// Zorunlu parola politikası var mı?
        /// </summary>
        public bool EnforcePasswordPolicy { get; set; }

        /// <summary>
        /// Destek kanalı bağlantısı (örn: özel support linki).
        /// </summary>
        public string? SupportContactUrl { get; set; }

        public virtual Tenant? Tenant { get; set; }
    }
}
