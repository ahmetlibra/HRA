using ProvisioningService.DBService.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;


namespace ProvisioningService.DBService.Concrete
{
    public class MongoDbProvisioner : IDbProvisioner
    {
        private readonly IMongoClient _mongoClient;
        public string Type => "MongoDB";

        public MongoDbProvisioner(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
        }

        public async Task ProvisionTenantDatabaseAsync(string tenantCode)
        {
            var dbName = $"tenant_{tenantCode.ToLower()}";

            // MongoDB'de veritabanı, içine ilk collection/document eklendiğinde otomatik oluşur.
            // Biz burada yine de bir "ping" atabilir veya boş bir collection oluşturabiliriz.
            var database = _mongoClient.GetDatabase(dbName);
            await database.CreateCollectionAsync("default_collection");

            // Gerekirse başlangıç index'leri vs. burada oluşturulabilir.
        }
    }
}
