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
    public class ClientID
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Client_Id { get; set; }
        public string Secret_Key { get; set; }
        public string Client_Mobile { get; set; }

        public async Task<bool> Validate(string client_id, string secret_key)
        {
            var mongoContext = new Models.MongoContext();
            var client = await mongoContext.ClientIDs.Find(x => x.Client_Id == client_id && x.Secret_Key == secret_key).FirstOrDefaultAsync();

            return client != null;
        }
    }
}