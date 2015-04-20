﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yumyum.Models
{
    [BsonIgnoreExtraElements]
    public class Rate
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string User { get; set; }
        public double Rates { get; set; }

        public DateTime CreatedDate { get; set; }
        
    }
}