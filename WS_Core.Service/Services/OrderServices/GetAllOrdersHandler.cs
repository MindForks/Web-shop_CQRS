using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MongoDB.Bson;
using WS_Core.Data.Interfaces;
using WS_Core.Domain.Dtos;
using WS_Core.Domain.Models;
using WS_Core.Domain.Queries.OrderQueries;
using WS_Core.Service.Dxos;

namespace WS_Core.Service.Services.OrderServices
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, List<OrderDto>>
    {
        private readonly IDatabase<Order> _orderDatabase;
        private readonly IDatabase<Product> _productDatabase;
        private readonly IMediator _mediator;
        private readonly ICustomDxos _customDxos;

        public GetAllOrdersHandler(IMediator mediator, IDatabase<Order> orderDatabase, ICustomDxos customDxos, IDatabase<Product> productDatabase)
        {
            _orderDatabase = orderDatabase ?? throw new ArgumentNullException(nameof(orderDatabase));
            _productDatabase = productDatabase ?? throw new ArgumentNullException(nameof(productDatabase));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _customDxos = customDxos ?? throw new ArgumentNullException(nameof(customDxos));
        }

        public async Task<List<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = (await _orderDatabase.GetAllAsync());

            if (orders.Count != 0)
            {
                Console.WriteLine($"Got a request get all orders");
                var ordersListDto = _customDxos.MapOrdersDto(orders);

                ordersListDto.ForEach(it =>
                    it.ProductNames = it.ProductIDs.Select(y => _productDatabase.GetOne(db => db.Id == new ObjectId(y)).Title).ToList()
                );
                return ordersListDto;
            }
            return null;
        }
    }
}
