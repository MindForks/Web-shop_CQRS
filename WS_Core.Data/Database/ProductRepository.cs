using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using WS_Core.Domain.Models;

namespace WS_Core.Data.Database
{
    public class ProductRepository : MongoDatabase<Product>
    {
        public ProductRepository() : base("product")
        {
        }
    }
}
