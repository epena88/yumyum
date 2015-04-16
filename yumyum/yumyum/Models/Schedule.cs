using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yumyum.Models
{
    [BsonIgnoreExtraElements]
    public class Schedule
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string StartHour { get; set; }
        public string EndHour { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}