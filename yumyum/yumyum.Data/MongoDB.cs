using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yumyum.Data
{
    public class MongoDB
    {
        public MongoClient mongoClient { get; set; }
        public MongoServer mongoServer { get; set; }
        public MongoDatabase mongoDataBase { get; set; }

        private List<MongoServerAddress> servers;

        public MongoDB()
        {
            var databaseName = ConfigurationSettings.AppSettings["databaseName"].ToString();
            var usr = ConfigurationSettings.AppSettings["usr"].ToString();
            var pwd = ConfigurationSettings.AppSettings["pwd"].ToString();
            var serverA = ConfigurationSettings.AppSettings["serverA"].ToString();
            var portA = ConfigurationSettings.AppSettings["portA"].ToString();

            servers = new List<MongoServerAddress>();
            servers.Add(new MongoServerAddress(serverA, int.Parse(portA)));

            MongoClientSettings settings = new MongoClientSettings
            {
                Credentials = new[] { MongoCredential.CreateMongoCRCredential(databaseName, usr, pwd) },
                Servers = servers,
                MaxConnectionPoolSize = 1500
            };

            this.mongoClient = new MongoClient(settings);
            this.mongoServer = this.mongoClient.GetServer();
            this.mongoDataBase = this.mongoServer.GetDatabase(databaseName);
        }

        public List<T> GetAllItems<T>(string collection)
        {
            return this.mongoDataBase.GetCollection<T>(collection).FindAll().ToList<T>();
        }

        public List<T> GetAllItems<T>(string collection, IMongoQuery query)
        {
            return this.mongoDataBase.GetCollection<T>(collection).Find(query).ToList<T>();
        }

        public T GetItemById<T>(string collection, IMongoQuery query)
        {
            return this.mongoDataBase.GetCollection<T>(collection).Find(query).FirstOrDefault();
        }

        public T AddItem<T>(string collection, T item)
        {
            this.mongoDataBase.GetCollection<T>(collection).Insert(item);
            return item;
        }

        public bool RemoveItem<T>(string collection, string id)
        {
            var result = this.mongoDataBase.GetCollection<T>(collection).Remove(Query.EQ("_id", id));
            return result.DocumentsAffected == 1;
        }

        public bool UpdateItem<T>(string collection, string id, T item)
        {
            var _item = GetItemById<T>(collection, Query.EQ("_id", id));
            _item = item;
            var result = this.mongoDataBase.GetCollection<T>(collection).Save(_item);
            return result.UpdatedExisting;
        }

        public static string GetNewId()
        {
            return ObjectId.GenerateNewId().ToString();
        }
    }
}
