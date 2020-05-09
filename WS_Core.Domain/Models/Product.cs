using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace WS_Core.Domain.Models
{
    public class Product
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }

        public int CountInStock { get; set; }

        [BsonIgnoreIfNull]
        public Manufacturer Manufacturer { get; set; }
    }
}
