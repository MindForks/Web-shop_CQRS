using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WS_Core.Data.Interfaces;
using WS_Core.Domain.Events;
using WS_Core.Domain.Models;

namespace WS_Core.Service.Subscribers
{
    public class ProductCreatedHandler : INotificationHandler<ItemCreatedEvent>
    {
        private readonly IDatabase<Product> _productDatabase;

        public ProductCreatedHandler(IDatabase<Product> productDatabase)
        {
            _productDatabase = productDatabase;

        }

        public async Task Handle(ItemCreatedEvent notification, CancellationToken cancellationToken)
        {
            var product = await _productDatabase.GetAsync(e => e.Id == notification.ProductId);

            if (product == null)
            {
                Console.WriteLine("CreateEventHandler: Item is not found by customer id from publisher");
                //_logger.LogWarning("Product is not found by customer id from publisher");
            }
            else
            {
                Console.WriteLine("CreateEventHandler: Item has found by customer id: {notification.CustomerId} from publisher");
                //_logger.LogInformation($"Product has found by customer id: {notification.CustomerId} from publisher");
            }
        }
    }
}
