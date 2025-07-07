using Application.Moduels.Invoice.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace OnlineStorApi.Controller
{
    [Route("api/Invoices")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly ISender _sender;
        public InvoiceController(ISender sender)
        {
            _sender = sender;
        }



        [HttpPost(Name = "AddInvoice")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> AddInvoice(CreateInvoiceCommand command)
        {
            if (command != null)
            {
                var ID = await _sender.Send(command);
                return CreatedAtRoute($"GetInvoiceByID", new { Id = ID }, command);
            }
            return BadRequest("Input data is null or invalid.");


        }





    }
}
