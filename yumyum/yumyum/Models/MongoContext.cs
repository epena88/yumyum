using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yumyum.Models
{
    public class MongoContext
    {
        public const string OWNERS_COLLECTION_NAME = "owners";
        public const string RESTAURANT_COLLECTION_NAME = "restaurants";

        private static readonly IMongoClient _client;
        private static readonly IMongoDatabase _database;
        private static List<MongoServerAddress> servers;
        static MongoContext()
        {
            var databaseName = ConfigurationSettings.AppSettings["databaseName"].ToString();
            var usr = ConfigurationSettings.AppSettings["usr"].ToString();
            var pwd = ConfigurationSettings.AppSettings["pwd"].ToString();
            var serverA = ConfigurationSettings.AppSettings["server"].ToString();
            var portA = ConfigurationSettings.AppSettings["port"].ToString();

            servers = new List<MongoServerAddress>();
            servers.Add(new MongoServerAddress(serverA, int.Parse(portA)));

            MongoClientSettings settings = new MongoClientSettings
            {
                Credentials = new[] { MongoCredential.CreateMongoCRCredential(databaseName, usr, pwd) },
                Servers = servers,
                MaxConnectionPoolSize = 1500
            };

            _client = new MongoClient(settings);
            _database = _client.GetDatabase(ConfigurationSettings.AppSettings["databaseName"].ToString());
        }

        public IMongoClient Client
        {
            get { return _client; }
        }

        public IMongoCollection<Owner> Owners
        {
            get { return _database.GetCollection<Owner>(OWNERS_COLLECTION_NAME); }
        }

        public IMongoCollection<Restaurant> Restaurants
        {
            get { return _database.GetCollection<Restaurant>(RESTAURANT_COLLECTION_NAME); }
        }
    }
}
