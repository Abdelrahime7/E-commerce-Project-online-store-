using Application.Services;
using Domain.entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStorAccess.Services;

namespace OnlineStorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemGalleryController : ControllerBase
    {


        private readonly ItemGalleryService _itemGalleryService;

        public ItemGalleryController(ItemGalleryService itemGalleryService)
        {
           _itemGalleryService = itemGalleryService;
        }

        [HttpGet("All", Name = "GetAllPeopl")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task< ActionResult<IEnumerable<ItemGallery>>> AllGalleriesAsync()
        {

            var ItemGalleryList = await _itemGalleryService.GettallAsync();
            if (ItemGalleryList.Count() == 0)
            {
                return NotFound("No ItemGalleryList Found");

            }
            return Ok(ItemGalleryList);

        }

        [HttpGet("{ID}", Name = "GetItemGalleryByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public async Task< ActionResult<ItemGallery>> GetItemGalleryByIDAsync(int ID)
        {
            if (ID > 1)
            {
                return BadRequest($"invalid {ID}");
            }

            // we retriev full ItemGallery here ,maybe we  need some of its method to do some logic
            var ItemGallery = await _itemGalleryService.GetByIDAsync(ID);

            if (ItemGallery is null)
            {
                return NotFound("No ItemGallery Found");
            }
            else
            {

                return Ok(ItemGallery);
            }
        }

        [HttpPost(Name = "AddItemGallery")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task< ActionResult<ItemGallery>> AddItemGalleryAsync(ItemGallery itemGallery)
        {
            if (itemGallery == null || String.IsNullOrEmpty(itemGallery.ImageLink))

            {
                return BadRequest($"invalid ItemGallery Data ");
            }


            var ItemGalleryID =await _itemGalleryService.AddAsync(itemGallery);


            if (ItemGalleryID != 0)
            {
                return CreatedAtRoute($"GetItemGalleryByID", new { Id = itemGallery.Id }, itemGallery);
                }
            else
                return BadRequest($"Saving Failed  :( ");

        }


        [HttpPut("{ID}", Name = "UdateItemGallery")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async  Task<ActionResult<ItemGallery>> UbdateItemGalleryAsync(int ID, ItemGallery UpdatedItemGallery)
        {
            if (ID < 1 || UpdatedItemGallery == null)
            {
                return BadRequest($"invalid Data ");
            }


            var ItemGallery = await _itemGalleryService.GetByIDAsync(ID);



            if (ItemGallery != null)
            {

                UpdatedItemGallery.Id = ItemGallery.Id;

                await _itemGalleryService.UpdateAsync(UpdatedItemGallery);
                {
                    return Ok($"ItemGallery with ID = {ID} Updated Successfully ");
                }

            }
            return BadRequest($"invalid  Data ");

        }


        [HttpDelete("{ID}", Name = "DeleteItemGallery")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task< ActionResult> DeletItemGalleryAsync(int ID)
        {

            if (ID < 1)
            {
                return BadRequest("Invalid ID");
            }
            var ItemGallery = await _itemGalleryService.GetByIDAsync(ID);

            if (ItemGallery != null)
            {

                if (await _itemGalleryService.DeleteAsync(ID))
                {
                    return Ok($"ItemGallery with ID = {ID} Deleted Successfully ");
                }

            }
            return BadRequest($" there is NO ItemGallery with ID = {ID} ");

        }

    }
}
