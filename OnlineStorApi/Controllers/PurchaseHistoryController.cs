using Application.Services;
using Domain.entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace OnlineStorApi.Controller
{
    [Route("api/PurchaseHistoryHistory")]
    [ApiController]
    public class PurchaseHistoryHistoryController : ControllerBase
    {

        private readonly PurchasHistoryService _purchaseHistoryService;

        public PurchaseHistoryHistoryController(PurchasHistoryService purchasHistoryService)
        {
            _purchaseHistoryService = purchasHistoryService;
        }

        [HttpGet("All", Name = "GetAllPeopl")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<IEnumerable<PurchaseHistory>>> AllPurchaseHistorysAsync()
        {

            var PurchaseHistorysList = await _purchaseHistoryService.GettallAsync();
            if (PurchaseHistorysList.Count() == 0)
            {
                return NotFound("No PurchaseHistorys Found");

            }
            return Ok(PurchaseHistorysList);

        }

        [HttpGet("{ID}", Name = "GetPurchaseHistoryByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<PurchaseHistory>> GetPurchaseHistoryByIDAsync(int ID)
        {
            if (ID > 1)
            {
                return BadRequest($"invalid {ID}");
            }

            // we retriev full PurchaseHistory here ,maybe we  need some of its method to do some logic
            var PurchaseHistory =await _purchaseHistoryService.GetByIDAsync(ID);

            if (PurchaseHistory is null)
            {
                return NotFound("No PurchaseHistory found");
            }
            else
            {

                return Ok(PurchaseHistory);
            }
        }

        [HttpPost(Name = "AddPurchaseHistory")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PurchaseHistory>> AddPurchaseHistoryAsync(PurchaseHistory PurchaseHistory)
        {
            if (PurchaseHistory == null)
            {
                return BadRequest($"invalid PurchaseHistory Data ");
            }


            var PurchaseHistoryID =await _purchaseHistoryService.AddAsync(PurchaseHistory);


            if (PurchaseHistoryID != 0)
            {
                return CreatedAtRoute($"GetPurchaseHistoryByID", new { id = PurchaseHistoryID }, PurchaseHistory);
            }
            else
                return BadRequest($"Saving Failed  :( ");

        }


        [HttpPut("{ID}", Name = "UdatePurchaseHistory")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PurchaseHistory>> UbdatePurchaseHistoryAsync(int ID, PurchaseHistory UpdatedPurchaseHistory)
        {
            if (ID < 1)
            {
                return BadRequest($"invalid Data ");
            }


            var PurchaseHistory =await _purchaseHistoryService.GetByIDAsync(ID);



            if (PurchaseHistory != null)
            {

                UpdatedPurchaseHistory.Id = PurchaseHistory.Id;

              await  _purchaseHistoryService.UpdateAsync(UpdatedPurchaseHistory);
                {
                    return Ok($"PurchaseHistory with ID = {ID} Updated Successfully ");
                }

            }
            return BadRequest($"invalid PurchaseHistory Data ");

        }


        [HttpDelete("{ID}", Name = "DeletePurchaseHistory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeletPurchaseHistoryAsync(int ID)
        {

            if (ID < 1)
            {
                return BadRequest("Invalid ID");
            }
            var PurchaseHistory =await _purchaseHistoryService.GetByIDAsync(ID);

            if (PurchaseHistory != null)
            {

                if (await _purchaseHistoryService.DeleteAsync(ID))
                {
                    return Ok($"PurchaseHistory with ID = {ID} Deleted Successfully ");
                }

            }
            return BadRequest($" there is NO PurchaseHistory with ID = {ID} ");

        }
    }
}
