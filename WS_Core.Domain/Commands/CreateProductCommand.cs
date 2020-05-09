using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WS_Core.Domain.Dtos;

namespace WS_Core.Domain.Commands
{
    public class CreateProductCommand : CommandBase<ProductDto>
    {
        public CreateProductCommand()
        {
        }

        [JsonConstructor]
        public CreateProductCommand(string title, double price, int countInStock, ManufacturerDto manufacturer)
        {
            Title = title;
            Price = price;
            CountInStock = countInStock;
            Manufacturer = manufacturer;
        }

        [JsonProperty("title")]
        [Required]
        public string Title { get; }

        [JsonProperty("price")]
        [Required]
        public double Price { get; }

        [JsonProperty("countInStock")]
        [Required]
        public int CountInStock { get; }

        [JsonProperty("manufacturer")]
        [Required]
        public ManufacturerDto Manufacturer { get; }
    }
}
