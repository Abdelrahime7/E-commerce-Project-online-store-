using Application.Services;
using Domain.entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStorAccess.Services;

namespace OnlineStorApi.Controllers
{
    [Route("api/Salles")]
    [ApiController]
    public class SallesController : ControllerBase
    {

        private readonly SalesService _salesService;

        public SallesController(SalesService salesService)
        {
            _salesService = salesService;
        }

        [HttpGet("All", Name = "GetAllPeopl")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<IEnumerable<Sale>>> AllSallesAsync()
        {

            var SallesList = await _salesService.GettallAsync();
            if (SallesList.Count() == 0)
            {
                return NotFound("No Salles Found");

            }
            return Ok(SallesList);

        }

        [HttpGet("{ID}", Name = "GetSaleByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Sale>> GetSaleByIDAsync(int ID)
        {
            if (ID > 1)
            {
                return BadRequest($"invalid {ID}");
            }

            // we retriev full Sale here ,maybe we  need some of its method to do some logic
            var Sale = await _salesService.GetByIDAsync(ID);

            if (Sale is null)
            {
                return NotFound("No Sale found");
            }
            else
            {

                return Ok(Sale);
            }
        }

        [HttpPost(Name = "AddSale")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Sale>> AddSaleAsync(Sale Sale)
        {
            if (Sale == null)

            {
                return BadRequest($"invalid Sale Data ");
            }


            var SaleID = await _salesService.AddAsync(Sale);


            if (SaleID != 0)
            {
                return CreatedAtRoute($"GetSaleByID", SaleID);
            }
            else
                return BadRequest($"Saving Failed  :( ");

        }


        [HttpPut("{ID}", Name = "UdateSale")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Sale>> UbdateSaleAsync(int ID, Sale UpdatedSale)
        {
            if (ID < 1)
            {
                return BadRequest($"invalid Data ");
            }


            var Sale = await _salesService.GetByIDAsync(ID);



            if (Sale != null)
            {

                UpdatedSale.Id = Sale.Id;

                await _salesService.UpdateAsync(UpdatedSale);
                {
                    return Ok($"Sale with ID = {ID} Updated Successfully ");
                }

            }
            return BadRequest($"invalid Sale Data ");

        }


        [HttpDelete("{ID}", Name = "DeleteSale")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeletSaleAsync(int ID)
        {

            if (ID < 1)
            {
                return BadRequest("Invalid ID");
            }
            var Sale = await _salesService.GetByIDAsync(ID);

            if (Sale != null)
            {

                if (await _salesService.DeleteAsync(ID))
                {
                    return Ok($"Sale with ID = {ID} Deleted Successfully ");
                }

            }
            return BadRequest($" there is NO Sale with ID = {ID} ");

        }

    }
}
