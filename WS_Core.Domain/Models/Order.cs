using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace WS_Core.Domain.Models
{
    public class Order
    {
        public Order()
        {
            ProductIDs = new List<MongoDBRef>();
        }

        [BsonId]
        public ObjectId Id { get; set; }

        public List<MongoDBRef> ProductIDs { get; set; }

        public string UserName { get; set; }

        public override string ToString()
        {
            var prod = "";
            foreach (var item in ProductIDs)
            { 
                prod += item.Id + ", ";
            }
           
            return string.Format("Id: {0} \nProducts: {1} \nUserName: {2} \n--------", Id, prod, UserName);
        }
    }
}
