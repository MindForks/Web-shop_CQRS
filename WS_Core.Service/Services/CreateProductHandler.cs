using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WS_Core.Data.Interfaces;
using WS_Core.Domain.Commands;
using WS_Core.Domain.Dtos;
using WS_Core.Domain.Models;
using WS_Core.Service.Dxos;

namespace WS_Core.Service.Services
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly IDatabase<Product> _productDatabase;
        private readonly IMediator _mediator;
        private readonly IProductDxos _productDxos;


        public CreateProductHandler(IMediator mediator, IDatabase<Product> productDatabase, IProductDxos productDxos)
        {
            _productDatabase = productDatabase ?? throw new ArgumentNullException(nameof(productDatabase));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _productDxos = productDxos ?? throw new ArgumentNullException(nameof(productDxos));
        }

        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product() {CountInStock = request.CountInStock, Price = request.Price, Title = request.Title, Manufacturer = _productDxos.MapManufacturer(request.Manufacturer) };
            await _productDatabase.InsertOneAsync(product);

            await _mediator.Publish(new Domain.Events.ProductCreatedEvent(product.Id), cancellationToken);

            var productDto = _productDxos.MapProductDto(product);
            return productDto;
        }
    }
}
