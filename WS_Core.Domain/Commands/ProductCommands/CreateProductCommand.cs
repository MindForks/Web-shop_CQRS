using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WS_Core.Domain.Dtos;

namespace WS_Core.Domain.Commands.ProductCommands
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
        public string Title { get; }

        [JsonProperty("price")]
        public double Price { get; }

        [JsonProperty("countInStock")]
        public int CountInStock { get; }

        [JsonProperty("manufacturer")]
        public ManufacturerDto Manufacturer { get; }
    }
}
