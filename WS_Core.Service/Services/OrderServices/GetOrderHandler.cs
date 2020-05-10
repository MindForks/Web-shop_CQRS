using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WS_Core.Data.Interfaces;
using WS_Core.Domain.Dtos;
using WS_Core.Domain.Models;
using WS_Core.Domain.Queries.OrderQueries;
using WS_Core.Service.Dxos;

namespace WS_Core.Service.Services.OrderServices
{
    public class GetOrderHandler : IRequestHandler<GetOrderQuery, OrderDto>
    {
        private readonly IDatabase<Order> _orderDatabase;
        private readonly IMediator _mediator;
        private readonly ICustomDxos _cutomDxos;

        public GetOrderHandler(IMediator mediator, IDatabase<Order> orderDatabase, ICustomDxos cutomDxos)
        {
            _orderDatabase = orderDatabase ?? throw new ArgumentNullException(nameof(orderDatabase));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _cutomDxos = cutomDxos ?? throw new ArgumentNullException(nameof(cutomDxos));
        }

        public async Task<OrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var Order = (await _orderDatabase.GetAsync(i => i.Id == request.Id)).SingleOrDefault();

            if (Order != null)
            {
                Console.WriteLine($"Got a request get Order Id: {Order.Id}");
                var OrderDto = _cutomDxos.MapOrderDto(Order);
                return OrderDto;
            }
            // return Task.FromResult(_OrderDatabase.GetOne(i => i.Id == request.Id));
            return null;
        }
    }

}
