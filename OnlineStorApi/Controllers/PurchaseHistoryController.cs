using Application.Moduels.Purchase.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStorApi.Controller
{
    [Route("api/PurchasesHistory")]
    [ApiController]
    public class PurchaseHistoryHistoryController : ControllerBase
    {
        private readonly ISender _sender;
        public PurchaseHistoryHistoryController(ISender sender)
        {
            _sender = sender;
        }



        [HttpPost(Name = "AddPurchaseHistory")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> AddPurchase(CreatePurchaseCommand command)
        {
            if (command != null)
            {
                var ID = await _sender.Send(command);
                return CreatedAtRoute($"GetPurchaseByID", new { Id = ID }, command);
            }
            return BadRequest("Input data is null or invalid.");


        }


    }
}
