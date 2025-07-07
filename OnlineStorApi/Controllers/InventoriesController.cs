
using Application.Moduels.Inventory.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace OnlineStorApi.Controller
{
    [Route("api/Inventories")]
    [ApiController]
    public class InventoriesController : ControllerBase
    {
        private readonly ISender _sender;
        public InventoriesController(ISender sender)
        {
            _sender = sender;
        }



        [HttpPost(Name = "AddInventory")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> AddInventory(CreateInventoryCommand command)
        {
            if (command != null)
            {
                var ID = await _sender.Send(command);
                return CreatedAtRoute($"GetInventoryByID", new { Id = ID }, command);
            }
            return BadRequest("Input data is null or invalid.");


        }



    }
}
