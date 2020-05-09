using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using WS_Core.Domain.Dtos;

namespace WS_Core.Domain.Queries.ProductQueries
{
    public class GetAllProductsQuery : QueryBase<List<ProductDto>>
    {
        [JsonConstructor]
        public GetAllProductsQuery()
        {

        }
    }
}
