using WS_Core.Domain.Models;

namespace WS_Core.Data.Database
{
    public class OrderRepository : MongoDatabase<Order>
    {
        public OrderRepository() : base("product")
        {
        }
    }
}
