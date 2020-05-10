using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using WS_Core.Domain.Models;

namespace WS_Core.Data.Database
{
    public class ProductRepository : MongoDatabase<Product>
    {
        public const string collectionName = "product";
        public ProductRepository() : base(collectionName)
        {
        }
    }
}
