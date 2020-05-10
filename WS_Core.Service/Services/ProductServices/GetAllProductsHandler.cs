using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WS_Core.Data.Interfaces;
using WS_Core.Domain.Dtos;
using WS_Core.Domain.Models;
using WS_Core.Domain.Queries.ProductQueries;
using WS_Core.Service.Dxos;

namespace WS_Core.Service.Services.ProductServices
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
    {
        private readonly IDatabase<Product> _productDatabase;
        private readonly IMediator _mediator;
        private readonly ICustomDxos _productDxos;

        public GetAllProductsHandler(IMediator mediator, IDatabase<Product> productDatabase, ICustomDxos productDxos)
        {
            _productDatabase = productDatabase ?? throw new ArgumentNullException(nameof(productDatabase));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _productDxos = productDxos ?? throw new ArgumentNullException(nameof(productDxos));
        }

        public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = (await _productDatabase.GetAllAsync());

            if (products.Count != 0)
            {
                Console.WriteLine($"Got a request get all products");
                var productsListDto = _productDxos.MapProductsDto(products);
                return productsListDto;
            }
            // return Task.FromResult(_productDatabase.GetOne(i => i.Id == request.Id));
            return null;
        }
    }
}
