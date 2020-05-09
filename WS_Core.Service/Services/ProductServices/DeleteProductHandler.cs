using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WS_Core.Data.Interfaces;
using WS_Core.Domain.Commands.ProductCommands;
using WS_Core.Domain.Models;

namespace WS_Core.Service.Services.ProductServices
{
    class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IDatabase<Product> _productDatabase;


        public DeleteProductHandler(IDatabase<Product> productDatabase)
        {
            _productDatabase = productDatabase ?? throw new ArgumentNullException(nameof(productDatabase));
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = (await _productDatabase.GetAsync(i => i.Id == request.Id)).SingleOrDefault();
            if (product != null)
            {
                await _productDatabase.DeleteOneAsync(i => i.Id == request.Id);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
