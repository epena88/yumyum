using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yumyum.Models
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonId]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Phone")]
        public string Phone { get; set; }

        [BsonElement("LastModified")]
        public DateTime LastModified { get; set; }
    }
}