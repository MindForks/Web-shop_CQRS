using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using Newtonsoft.Json;
using WS_Core.Domain.Models;

namespace WS_Core.Domain.Queries
{
    public class GetProductrQuery : QueryBase<Product>
    {
        public GetProductrQuery()
        {
        }

        [JsonConstructor]
        public GetProductrQuery(ObjectId id)
        {
            Id = id;
        }

        [JsonProperty("id")]
        [Required]
        public ObjectId Id { get; set; }
    }
}
