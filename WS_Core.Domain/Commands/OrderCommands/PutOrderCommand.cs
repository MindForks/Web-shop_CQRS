using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MongoDB.Bson;
using Newtonsoft.Json;
using WS_Core.Domain.Dtos;

namespace WS_Core.Domain.Commands.OrderCommands
{
    public class PutOrderCommand : CommandBase<OrderDto>
    {

        [JsonConstructor]
        public PutOrderCommand(string id, string userName, List<string> productIDs)
        {
            Id = new ObjectId(id);
            UserName = userName;
            ProductIDs = productIDs;
        }

        [JsonProperty("id")]
        [Required]
        public ObjectId Id { get; }

        [JsonProperty("userName")]
        public string UserName { get; }

        [JsonProperty("ProductIDs")]
        public List<string> ProductIDs { get; }
    }
}
