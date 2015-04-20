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

        static MongoContext()
        {
            var connectionString = string.Format("mongodb://{0}:{1}", ConfigurationSettings.AppSettings["server"].ToString(), ConfigurationSettings.AppSettings["port"].ToString());
            _client = new MongoClient(connectionString);
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
