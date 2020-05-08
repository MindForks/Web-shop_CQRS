using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WS_Core.Data.Database;
using WS_Core.Data.Interfaces;
using WS_Core.Domain.Models;
using WS_Core.Domain.Queries;
using System.Linq;
using System;

namespace WS_Core.Service.Services
{
    public class GetProductHandler : IRequestHandler<GetProductrQuery, Product>
    {
        private readonly IDatabase<Product> _productDatabase;
        private readonly IMediator _mediator;
        //  private readonly ICustomerDxos _customerDxos;

        public GetProductHandler(IMediator mediator, IDatabase<Product> productDatabase)
        {
            _productDatabase = productDatabase ?? throw new ArgumentNullException(nameof(productDatabase));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<Product> Handle(GetProductrQuery request, CancellationToken cancellationToken)
        {
            var productsList =  await _productDatabase.GetAsync(i => i.Id == request.Id);
            return productsList.SingleOrDefault();

            // return Task.FromResult(_productDatabase.GetOne(i => i.Id == request.Id));
        }
    }
}
