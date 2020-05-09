using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WS_Core.Domain.Commands.ProductCommands;
using WS_Core.Domain.Dtos;
using WS_Core.Domain.Queries.ProductQueries;

namespace WS_Core.Api.Controllers
{
    public class ProductController : ApiControllerBase
    {

        public ProductController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet()]
        [ProducesResponseType(typeof(List<ProductDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ProductDto>>> GetAllProductsAsync()
        {
            return Single(await QueryAsync(new GetAllProductsQuery()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> GetProductAsync(string id)
        {
            return Single(await QueryAsync(new GetProductrQuery(id)));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateProductAsync([FromBody] CreateProductCommand command)
        {
            return Ok(await CommandAsync(command));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PutProductAsync([FromBody] PutProductCommand command)
        {
            return Ok(await CommandAsync(command));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteProductAsync(string id)
        {
            var isDeleted = await CommandAsync(new DeleteProductCommand(id));

            if(!isDeleted)
                return NotFound();

            return Ok();
        }

    }
}
