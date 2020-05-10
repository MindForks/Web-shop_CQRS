using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MongoDB.Driver;
using WS_Core.Data.Database;
using WS_Core.Data.Interfaces;
using WS_Core.Domain.Commands.OrderCommands;
using WS_Core.Domain.Dtos;
using WS_Core.Domain.Models;
using WS_Core.Service.Dxos;

namespace WS_Core.Service.Services.OrderServices
{
    public class PutOrderHandler : IRequestHandler<PutOrderCommand, OrderDto>
    {
        private readonly IDatabase<Order> _orderDatabase;
        private readonly IMediator _mediator;
        private readonly ICustomDxos _customDxos;


        public PutOrderHandler(IMediator mediator, IDatabase<Order> orderDatabase, ICustomDxos customDxos)
        {
            _orderDatabase = orderDatabase ?? throw new ArgumentNullException(nameof(orderDatabase));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _customDxos = customDxos ?? throw new ArgumentNullException(nameof(customDxos));
        }

        public async Task<OrderDto> Handle(PutOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order() {Id = request.Id, UserName = request.UserName, ProductIDs = request.ProductIDs.Select(y => new MongoDBRef(ProductRepository.collectionName, y)).ToList() };
            await _orderDatabase.ReplaceOneAsync(i => i.Id == order.Id, order);

            var orderDto = _customDxos.MapOrderDto(order);
            return orderDto;
        }
    }

}
