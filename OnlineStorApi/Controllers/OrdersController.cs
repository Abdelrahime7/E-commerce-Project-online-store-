using Application.Moduels.Order.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStorApi.Controller
{
    [Route("api/Orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ISender _sender;
        public OrdersController(ISender sender)
        {
            _sender = sender;
        }



        [HttpPost(Name = "AddOrder")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> AddOrder(CreateOrderCommand command)
        {
            if (command != null)
            {
                var ID = await _sender.Send(command);
                return CreatedAtRoute($"GetOrderByID", new { Id = ID }, command);
            }
            return BadRequest("Input data is null or invalid.");


        }


    }
}
