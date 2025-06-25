using Domain.entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStorAccess.Services;

namespace OnlineStorApi.Controllers
{
    [Route("api/Invoices")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly InvoicesServices _invoicesServices;

        public InvoicesController(InvoicesServices invoicesServices)
        {
            _invoicesServices = invoicesServices;
        }

        // GET: api/Inventories
        [HttpGet("All", Name = "GetAllInvoices")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task< ActionResult<IEnumerable<Invoice>>> GetAlllInventories()
        {
            var InvoiceList = await _invoicesServices.GettallAsync(); 
            if (InvoiceList.Count() == 0)
            {
                return NotFound("No Invoices Found");

            }
            return Ok(InvoiceList);
        }

        // GET: api/Inventories/5
        [HttpGet("{ID}", Name = "GetInvoiceByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task< ActionResult<Inventory>> GetInvoiceAsync(int id)
        {

            if (id < 0)
            {
                return BadRequest("Invalid ID");
            }
            var Invoice = await _invoicesServices.GetByIDAsync(id);

            if (Invoice == null)
            {
                return NotFound("No Invoice found");
            }

            return Ok(Invoice);
        }

        // PUT: api/Inventories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost(Name = "AddInvoice")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Invoice>> AddInvoiceAsync(Invoice invoice)
        {

            if (invoice == null)
            {
                return BadRequest($"invalid invoice Data ");
            }


            var invoiceID =await _invoicesServices.AddAsync(invoice);


            if (invoiceID != 0)
            {
                return CreatedAtRoute($"GetInvoiceByID", new { id = invoice.Id }, invoice);
            }
            else
                return BadRequest($"adding Failed  :( ");

        }

        [HttpPut("{ID}", Name = "UdateInvoice")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task< ActionResult<Inventory>> UpdatInvoiceAsync(int ID, Invoice UpdatedInvoice)
        {
            if (ID < 1 || UpdatedInvoice == null )
            {
                return BadRequest($"invalid Data ");
            }

            var Invoice =await _invoicesServices.GetByIDAsync(ID);

            if (Invoice != null)

            {
                UpdatedInvoice.Id = Invoice.Id;
               await _invoicesServices.UpdateAsync(UpdatedInvoice);
                return Ok($"Invoice with ID = {ID} Updated Successfully ");

            }


            return BadRequest($"invalid  Data ");

        }


        [HttpDelete("{ID}", Name = "DeleteInvoice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task< ActionResult> DeletInvoiceAsync(int ID)
        {

            if (ID < 1)
            {
                return BadRequest("Invalid ID");
            }
            var Invoice =await _invoicesServices.GetByIDAsync(ID);

            if (Invoice != null)
            {

                if (await _invoicesServices.DeleteAsync(ID))
                {
                    return Ok($"Invoice with ID = {ID} Deleted Successfully ");
                }

            }
            return BadRequest($" there is NO Invoice with ID = {ID} ");

        }






    }
}
