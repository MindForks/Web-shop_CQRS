using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WS_Core.Data.Database;
using WS_Core.Data.Interfaces;
using WS_Core.Domain.Commands;
using WS_Core.Domain.Models;
using WS_Core.Service.Dxos;

namespace WS_Core.Service.Services
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IDatabase<Product> _productDatabase;
        private readonly IMediator _mediator;

        public CreateProductHandler(IMediator mediator, IDatabase<Product> productDatabase)
        {
            _productDatabase = productDatabase ?? throw new ArgumentNullException(nameof(productDatabase));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product() { Id = request.Id, CountInStock = request.CountInStock, Price = request.Price, Title = request.Title };
            _productDatabase.InsertOne(product);

            await _mediator.Publish(new Domain.Events.ProductCreatedEvent(product.Id), cancellationToken);

            return product;
        }
    }
}
