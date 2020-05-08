using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using WS_Core.Data.Database;
using WS_Core.Data.Interfaces;
using System.Linq;
using WS_Core.Domain.Models;

namespace WS_Core.Data.Services
{
    public class ProductService
    {
        private IDatabase<Product> _mongoItem;
        public static readonly string CollectionName = "product";
        public ProductService()
        {
            _mongoItem = new MongoDatabase<Product>(CollectionName);
        } 

        public Product GetById(ObjectId id)
        {
            return _mongoItem.GetOne(i => i.Id == id);
        }

        public void Create(Product product)
        {
            _mongoItem.InsertOne(product);
        }

        public void Update(Product product)
        {
            _mongoItem.ReplaceOne(i => i.Id == product.Id, product);
        }

        public void Delete(ObjectId id)
        {
            var product = _mongoItem.GetOne(i => i.Id == id);
            if (product != null)
            {
                _mongoItem.DeleteOne(i => i.Id == id);
            }
        }
      
        public IQueryable<Product> GetAll()
        {
            return _mongoItem.Query;
        }
    }
}
