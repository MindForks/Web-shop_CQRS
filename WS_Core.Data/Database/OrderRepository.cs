using WS_Core.Domain.Models;

namespace WS_Core.Data.Database
{
    public class OrderRepository : MongoDatabase<Order>
    {
        public const string collectionName = "order";
        public OrderRepository() : base(collectionName)
        {
        }
    }
}
