using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WS_Core.Data.Interfaces;
using WS_Core.Domain.Models;
using System.Linq;
using System;
using WS_Core.Domain.Dtos;
using WS_Core.Service.Dxos;
using WS_Core.Domain.Queries.ProductQueries;

namespace WS_Core.Service.Services.ProductServices
{
    public class GetProductHandler : IRequestHandler<GetProductrQuery, ProductDto>
    {
        private readonly IDatabase<Product> _productDatabase;
        private readonly IMediator _mediator;
        private readonly IProductDxos _productDxos;

        public GetProductHandler(IMediator mediator, IDatabase<Product> productDatabase, IProductDxos productDxos)
        {
            _productDatabase = productDatabase ?? throw new ArgumentNullException(nameof(productDatabase));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _productDxos = productDxos ?? throw new ArgumentNullException(nameof(productDxos));
        }

        public async Task<ProductDto> Handle(GetProductrQuery request, CancellationToken cancellationToken)
        {
            var product = (await _productDatabase.GetAsync(i => i.Id == request.Id)).SingleOrDefault();

            if (product != null)
            {
                Console.WriteLine($"Got a request get product Id: {product.Id}");
                var productDto = _productDxos.MapProductDto(product);
                return productDto;
            }
            // return Task.FromResult(_productDatabase.GetOne(i => i.Id == request.Id));
            return null;
        }
    }
}
