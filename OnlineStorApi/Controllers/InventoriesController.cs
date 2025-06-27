
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Domain.entities;
using Infrastructure.ADbContext;
using OnlineStorAccess.Services;

namespace OnlineStorApi.Controller
{
    [Route("api/Inventories")]
    [ApiController]
    public class InventoriesController : ControllerBase
    {
        private readonly InventoryService _inventoryService;

        public InventoriesController(InventoryService inventoryService)
        {
            _inventoryService= inventoryService;
        }

        // GET: api/Inventories
        [HttpGet("All", Name = "GetAllInventories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task< ActionResult<IEnumerable<Inventory>>> GetAlllInventories()
        {
            var InventoryList = await _inventoryService.GettallAsync();
            if (InventoryList.Count() == 0)
            {
                return NotFound("No Inventories Found");

            }
            return Ok(InventoryList);
        }

        // GET: api/Inventories/5
        [HttpGet("{ID}", Name = "GetInventoryByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task< ActionResult<Inventory>> GetInventory(int id)
        {

            if (id < 0) {
                return BadRequest("Invalid ID");
            }
            var inventory = await _inventoryService.GetByIDAsync(id);

            if (inventory == null)
            {
                return NotFound("No Inventory found");
            }

            return  Ok(inventory);
        }

        // PUT: api/Inventories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost(Name = "AddInventory")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task< ActionResult <Inventory>> AddInventory(Inventory inventory)
        {

            if (inventory == null)
            {
                return BadRequest($"invalid Inventory Data ");
            }


            var InventoryID = await _inventoryService.AddAsync(inventory);


            if (InventoryID != 0)
            {
                return CreatedAtRoute($"GetInventoryByID", new { id = inventory.Id }, inventory);
            }
            else
                return BadRequest($"adding Failed  :( ");

        }

        [HttpPut("{ID}", Name = "Udateinventory")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async  Task<ActionResult<Inventory>> UdatInventory(int ID, Inventory Updatedinventory)
        {
            if (ID < 1 || Updatedinventory == null)
            {
                return BadRequest($"invalid Data ");
            }

             var Inventory= await _inventoryService.GetByIDAsync(ID);

            if (Inventory!=null)
           
            {
                Updatedinventory.Id = Inventory.Id;
             await  _inventoryService.UpdateAsync(Updatedinventory);
                return Ok($"Inventory with ID = {ID} Updated Successfully ");
                
            }


                return BadRequest($"invalid  Data ");

        }


        [HttpDelete("{ID}", Name = "DeleteCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task < ActionResult> DeletInventor(int ID)
        {

            if (ID < 1)
            {
                return BadRequest("Invalid ID");
            }
            var inventory =await _inventoryService.GetByIDAsync(ID);

            if (inventory != null)
            {

                if (await _inventoryService.DeleteAsync(ID))
                {
                    return Ok($"Inventory with ID = {ID} Deleted Successfully ");
                }

            }
            return BadRequest($" there is NO inventory with ID = {ID} ");

        }



    }
}
