using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace WS_Core.Domain.Dtos
{
    public class ProductDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("countInStock")]
        public int CountInStock { get; set; }

        [JsonProperty("manufacturer")]
        public ManufacturerDto Manufacturer { get; set; }
    }
}
