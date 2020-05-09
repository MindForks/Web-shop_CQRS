using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using Newtonsoft.Json;
using WS_Core.Domain.Dtos;
using WS_Core.Domain.Models;

namespace WS_Core.Domain.Queries
{
    public class GetProductrQuery : QueryBase<ProductDto>
    {
        public GetProductrQuery()
        {
        }

        [JsonConstructor]
        public GetProductrQuery(string id)
        {
            Id = new ObjectId(id);
        }

        [JsonProperty("id")]
        [Required]
        public ObjectId Id { get; set; }
    }
}
