using Application.Services;
using Domain.entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStorAccess.Services;

namespace OnlineStorApi.Controllers
{
    [Route("api/Item")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        private readonly ItemService _itemService;

        public ItemController(ItemService itemService)
        {
           _itemService = itemService;
        }

        [HttpGet("All", Name = "GetAllItems")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<  ActionResult<IEnumerable<Item>>> AllItemsAsync()
        {

            var ItemList =  await _itemService.GettallAsync();
            if (ItemList.Count() == 0)
            {
                return NotFound("No Item Found");

            }
            return Ok(ItemList);

        }

        [HttpGet("{ID}", Name = "GetItemByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task < ActionResult<Item>> GetItemByIDAsync(int ID)
        {
            if (ID > 1)
            {
                return BadRequest($"invalid {ID}");
            }

            // we retriev full Item here ,maybe we  need some of its method to do some logic
            var Item =await _itemService.GetByIDAsync(ID);

            if (Item is null)
            {
                return NotFound("No Item found");
            }
            else
            {

                return Ok(Item);
            }
        }

        [HttpPost(Name = "AddItem")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Item>> AddItemAsync(Item item)
        {
            if (item == null )

            {
                return BadRequest($"invalid Item Data ");
            }


            var ItemID = await _itemService.AddAsync(item);


            if (ItemID != 0)
            {
                return CreatedAtRoute($"GetItemByID", new { id = ItemID }, item);
            }
            else
                return BadRequest($"Saving Failed  :( ");

        }


        [HttpPut("{ID}", Name = "UdateItem")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task< ActionResult<Item>> UbdateItemAsync(int ID, Item UpdatedItem)
        {
            if (ID < 1 || UpdatedItem == null )
            {
                return BadRequest($"invalid Data ");
            }


            var Item = await _itemService.GetByIDAsync(ID);



            if (Item != null)
            {

                UpdatedItem.Id = Item.Id;

               await _itemService.UpdateAsync(UpdatedItem);
                {
                    return Ok($"Item with ID = {ID} Updated Successfully ");
                }

            }
            return BadRequest($"invalid Item Data ");

        }


        [HttpDelete("{ID}", Name = "DeleteItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeletItemAsync(int ID)
        {

            if (ID < 1)
            {
                return BadRequest("Invalid ID");
            }
            var Item = await _itemService.GetByIDAsync(ID);

            if (Item != null)
            {

                if (await _itemService.DeleteAsync(ID))
                {
                    return Ok($"Item with ID = {ID} Deleted Successfully ");
                }

            }
            return BadRequest($" there is NO Item with ID = {ID} ");

        }


    }
}
