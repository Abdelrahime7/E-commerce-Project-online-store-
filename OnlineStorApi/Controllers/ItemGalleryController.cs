using Application.Moduels.ItemGallery.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStorApi.Controller
{
    [Route("api/ItemGallerries")]
    [ApiController]
    public class ItemGalleryController : ControllerBase
    {

        private readonly ISender _sender;
        public ItemGalleryController(ISender sender)
        {
            _sender = sender;
        }



        [HttpPost(Name = "AddItemGallery")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> AddItemGallery(CreateItemGalleryCommand command)
        {
            if (command != null)
            {
                var ID = await _sender.Send(command);
                return CreatedAtRoute($"GetItemGalleryByID", new { Id = ID }, command);
            }
            return BadRequest("Input data is null or invalid.");


        }


    }
}
