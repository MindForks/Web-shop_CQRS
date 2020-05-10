using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using Newtonsoft.Json;
using WS_Core.Domain.Dtos;

namespace WS_Core.Domain.Queries.OrderQueries
{
    public class GetOrderQuery : QueryBase<OrderDto>
    {
        public GetOrderQuery()
        {
        }

        [JsonConstructor]
        public GetOrderQuery(string id)
        {
            Id = new ObjectId(id);
        }

        [JsonProperty("id")]
        [Required]
        public ObjectId Id { get; set; }
    }
}
