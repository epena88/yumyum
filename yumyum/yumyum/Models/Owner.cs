using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}