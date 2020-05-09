using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MongoDB.Bson;
using Newtonsoft.Json;
using WS_Core.Domain.Dtos;
using WS_Core.Domain.Models;

namespace WS_Core.Domain.Commands.ProductCommands
{
    public class PutProductCommand : CommandBase<ProductDto>
    {
        public PutProductCommand()
        {
        }

        [JsonConstructor]
        public PutProductCommand(string id, string title, double price, int countInStock, ManufacturerDto manufacturer)
        {
            Id = new ObjectId(id);
            Title = title;
            Price = price;
            CountInStock = countInStock;
            Manufacturer = manufacturer;
        }

        [JsonProperty("id")]
        [Required]
        public ObjectId Id { get; }

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
