using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace WS_Core.Domain.Commands.OrderCommands
{
    public class DeleteOrderCommand : CommandBase<bool>
    {
        [JsonConstructor]
        public DeleteOrderCommand(string id)
        {
            Id = new ObjectId(id);
        }

        [JsonProperty("title")]
        [Required]
        public ObjectId Id { get; }
    }
}
