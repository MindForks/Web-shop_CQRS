using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using WS_Core.Domain.Events;

namespace WS_Core.Service.Subscribers
{
    public class ItemCreatedHandler : INotificationHandler<ItemCreatedEvent>
    {
        private readonly ILogger _logger;

        public ItemCreatedHandler(ILogger<ItemCreatedEvent> logger)
        {
            _logger = logger;
        }

        public Task Handle(ItemCreatedEvent notification, CancellationToken cancellationToken)
        {
           _logger.LogWarning("{0} successfully created with id:{1}", notification.ItemName, notification.ItemId);
            return Task.CompletedTask;  
        }
    }
}
