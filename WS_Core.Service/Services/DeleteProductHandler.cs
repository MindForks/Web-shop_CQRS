using System;
using System.Collections.Generic;
using System.Text;
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
    class DeleteProductHandler : IRequestHandler<DeleteProductCommand, string>
    {
        private readonly IDatabase<Product> _productDatabase;


        public DeleteProductHandler(IDatabase<Product> productDatabase)
        {
            _productDatabase = productDatabase ?? throw new ArgumentNullException(nameof(productDatabase));
        }

        public async Task<string> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _productDatabase.DeleteOneAsync(i => i.Id == request.Id);
            return "Successfully deleted";
        }
    }
}
