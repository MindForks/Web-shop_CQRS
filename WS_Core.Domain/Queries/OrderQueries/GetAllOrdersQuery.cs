using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using WS_Core.Domain.Dtos;

namespace WS_Core.Domain.Queries.OrderQueries
{
    public class GetAllOrdersQuery : QueryBase<List<OrderDto>>
    {
        [JsonConstructor]
        public GetAllOrdersQuery()
        {
        }
    }
}
