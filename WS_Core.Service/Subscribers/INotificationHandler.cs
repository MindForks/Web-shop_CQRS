using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WS_Core.Data.Interfaces;
using WS_Core.Domain.Events;
using WS_Core.Domain.Models;

namespace WS_Core.Service.Subscribers
{
    public class ProductCreatedHandler : INotificationHandler<ProductCreatedEvent>
    {
        private readonly IDatabase<Product> _productDatabase;

        public ProductCreatedHandler(IDatabase<Product> productDatabase)
        {
            _productDatabase = productDatabase;

        }

        public async Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
        {
            var product = await _productDatabase.GetAsync(e => e.Id == notification.ProductId);

            if (product == null)
            {
                Console.WriteLine("CreateEventHandler: Product is not found by customer id from publisher");
                //_logger.LogWarning("Product is not found by customer id from publisher");
            }
            else
            {
                Console.WriteLine("CreateEventHandler: Product has found by customer id: {notification.CustomerId} from publisher");
                //_logger.LogInformation($"Product has found by customer id: {notification.CustomerId} from publisher");
            }
        }
    }
}
