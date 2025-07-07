using Application.Moduels.Item.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStorApi.Controller
{
    [Route("api/Items")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        private readonly ISender _sender;
        public ItemController(ISender sender)
        {
            _sender = sender;
        }



        [HttpPost(Name = "AddItem")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> AddItem(CreateItemCommand command)
        {
            if (command != null)
            {
                var ID = await _sender.Send(command);
                return CreatedAtRoute($"GetItemByID", new { Id = ID }, command);
            }
            return BadRequest("Input data is null or invalid.");


        }

    }
}
