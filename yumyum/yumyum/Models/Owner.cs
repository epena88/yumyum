using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using yumyum.Tools;
using System.Text;

namespace yumyum.Models
{
    [BsonIgnoreExtraElements]
    public class Owner
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Mail")]
        public string Mail { get; set; }

        [BsonElement("Password")]
        public string Password { get; set; }

        [BsonElement("Phone")]
        public string Phone { get; set; }

        [BsonElement("LastModified ")]
        public DateTime LastModified { get; set; }

        [BsonElement("Salt ")]
        public string Salt { get; set; }

        public async Task<bool> Validate(string mail, string password)
        {
            var item = await new MongoContext().Owners.Find(x => x.Mail == mail).SingleOrDefaultAsync();
            dynamic owner = null;

            if (item != null)
                owner = await new MongoContext().Owners.Find(x => x.Mail == mail && x.Password == Crypto.GenerateSaltedSHA256(password, Encoding.UTF8.GetBytes(item.Salt))).SingleOrDefaultAsync();

            return owner != null;
        }
    }
}