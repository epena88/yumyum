using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace yumyum.Models
{
     [BsonIgnoreExtraElements]
    public class Client
    {
         [BsonRepresentation(BsonType.ObjectId)]
         public string Id { get; set; }

         public string ClientID { get; set; }
         public string SecretKey { get; set; }
         public string MobileClient { get; set; }

         public async Task<bool> Validate(string client_id, string secret_key)
         {
             var client = await new MongoContext().MobileClient.Find(x => x.ClientID == client_id && x.SecretKey == secret_key).SingleOrDefaultAsync();
             return client != null;
         }
    }
}