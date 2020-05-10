using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using WS_Core.Domain.Dtos;

namespace WS_Core.Domain.Commands.OrderCommands
{
    public class CreateOrderCommand : CommandBase<OrderDto>
    {

        [JsonConstructor]
        public CreateOrderCommand(string userName, List<string> productIDs)
        {
            UserName = userName;
            ProductIDs = productIDs;
        }

        [JsonProperty("userName")]
        public string UserName { get; }

        [JsonProperty("ProductIDs")]
        public List<string> ProductIDs { get; }
    }
}
