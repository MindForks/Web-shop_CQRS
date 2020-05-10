using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WS_Core.Data.Interfaces;
using WS_Core.Domain.Commands.OrderCommands;
using WS_Core.Domain.Models;

namespace WS_Core.Service.Services.OrderServices
{
    class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly IDatabase<Order> _orderDatabase;


        public DeleteOrderHandler(IDatabase<Order> orderDatabase)
        {
            _orderDatabase = orderDatabase ?? throw new ArgumentNullException(nameof(orderDatabase));
        }

        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var product = (await _orderDatabase.GetAsync(i => i.Id == request.Id)).SingleOrDefault();
            if (product != null)
            {
                await _orderDatabase.DeleteOneAsync(i => i.Id == request.Id);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
