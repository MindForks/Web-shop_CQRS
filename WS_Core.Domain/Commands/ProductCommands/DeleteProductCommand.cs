using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MongoDB.Bson;
using Newtonsoft.Json;
using WS_Core.Domain.Dtos;

namespace WS_Core.Domain.Commands.ProductCommands
{
    public class DeleteProductCommand : CommandBase<bool>
    {
        [JsonConstructor]
        public DeleteProductCommand(string id)
        {
            Id = new ObjectId(id);
        }

        [JsonProperty("title")]
        [Required]
        public ObjectId Id { get; }
    }
}
