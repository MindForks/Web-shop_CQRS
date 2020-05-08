using System;
using MediatR;
using MongoDB.Bson;

namespace WS_Core.Domain.Events
{
    public class ProductCreatedEvent : INotification
    {
        public ObjectId ProductId { get; }

        public ProductCreatedEvent(ObjectId productId)
        {
            ProductId = productId;
        }
    }
}
