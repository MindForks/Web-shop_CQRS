using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WS_Core.Domain.Commands.OrderCommands;
using WS_Core.Domain.Commands.ProductCommands;
using WS_Core.Domain.Dtos;
using WS_Core.Domain.Queries.OrderQueries;
using WS_Core.Domain.Queries.ProductQueries;

namespace WS_Core.Api.Controllers
{
    public class OrderController : ApiControllerBase
    {

        public OrderController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet()]
        [ProducesResponseType(typeof(List<OrderDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<OrderDto>>> GetAllOrdersAsync()
        {
            return Single(await QueryAsync(new GetAllOrdersQuery()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDto>> GetProductAsync(string id)
        {
            return Single(await QueryAsync(new GetOrderQuery(id)));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateOrderAsync([FromBody] CreateOrderCommand command)
        {
            return Ok(await CommandAsync(command));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PutOrderAsync([FromBody] PutOrderCommand command)
        {
            return Ok(await CommandAsync(command));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteOrderAsync(string id)
        {
            var isDeleted = await CommandAsync(new DeleteOrderCommand(id));

            if (!isDeleted)
                return NotFound();

            return Ok();
        }

    }
}
