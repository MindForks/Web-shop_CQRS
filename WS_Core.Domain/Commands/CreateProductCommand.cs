using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WS_Core.Domain.Models;

namespace WS_Core.Domain.Commands
{
     public class CreateProductCommand : CommandBase<Product>
    {
        public CreateProductCommand()
        {
        }

        [JsonConstructor]
        public CreateProductCommand(ObjectId id, string title, double price, int countInStock)
        {
            Id = id;
            Title = title;
            Price = price;
            CountInStock = countInStock;
        }

        [JsonProperty("id")]
        [Required]
        public ObjectId Id { get; }

        [JsonProperty("title")]
        [Required]
        public string Title { get; }

        [JsonProperty("зrice")]
        [Required]
        public double Price { get; }

        [JsonProperty("сountInStock")]
        [Required]
        public int CountInStock { get; }

    }
}
