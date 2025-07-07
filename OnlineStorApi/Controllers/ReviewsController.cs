using Application.Moduels.Review.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace OnlineStorApi.Controller
{
    [Route("api/Reviews")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ISender _sender;
        public ReviewsController(ISender sender)
        {
            _sender = sender;
        }



        [HttpPost(Name = "AddReview")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> AddReview(CreateReviewCommand command)
        {
            if (command != null)
            {
                var ID = await _sender.Send(command);
                return CreatedAtRoute($"GetReviewByID", new { Id = ID }, command);
            }
            return BadRequest("Input data is null or invalid.");


        }



    }
}
