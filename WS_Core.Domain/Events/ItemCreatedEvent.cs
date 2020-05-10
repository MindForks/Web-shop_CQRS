using System;
using MediatR;
using MongoDB.Bson;

namespace WS_Core.Domain.Events
{
    public class ItemCreatedEvent : INotification
    {
        public ObjectId ProductId { get; }

        public ItemCreatedEvent(ObjectId productId)
        {
            ProductId = productId;
        }
    }
}
