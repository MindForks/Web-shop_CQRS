using System;
using MediatR;
using MongoDB.Bson;

namespace WS_Core.Domain.Events
{
    public class ItemCreatedEvent : INotification
    {
        public ObjectId ItemId { get; }

        public string ItemName { get; }

        public ItemCreatedEvent(ObjectId itemId, string itemName)
        {
            ItemId = itemId;
            ItemName = itemName;
        }
    }
}
