using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yumyum.Models
{
    public class Owner
    {
        public ObjectId Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Gender")]
        public string Gender { get; set; }

        [BsonElement("Mail")]
        public string Mail { get; set; }

        [BsonElement("Password")]
        public string Password { get; set; }

        [BsonElement("Phone")]
        public string Phone { get; set; }
    }
}