using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace WS_Core.Domain.Dtos
{
    public class OrderDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("productIDs")]
        public List<string> ProductIDs { get; set; }

        [JsonProperty("productNames")]
        public List<string> ProductNames { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }
    }
}
