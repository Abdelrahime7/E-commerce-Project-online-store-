using Application.Moduels.Sale.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStorApi.Controller
{
    [Route("api/Sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISender _sender;
        public SalesController(ISender sender)
        {
            _sender = sender;
        }



        [HttpPost(Name = "AddSale")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> AddSale(CreateSaleCommand command)
        {
            if (command != null)
            {
                var ID = await _sender.Send(command);
                return CreatedAtRoute($"GetSaleByID", new { Id = ID }, command);
            }
            return BadRequest("Input data is null or invalid.");


        }


    }
}
