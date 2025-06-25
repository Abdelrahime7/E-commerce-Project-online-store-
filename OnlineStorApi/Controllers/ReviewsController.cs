using Application.Services;
using Domain.entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStorAccess.Services;

namespace OnlineStorApi.Controllers
{
    [Route("api/Reviews")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {


        private readonly ReviewService _reviewService;

        public ReviewsController(ReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("All", Name = "GetAllPeopl")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<IEnumerable<Review>>> AllReviewsAsync()
        {

            var ReviewsList = await _reviewService.GettallAsync();
            if (ReviewsList.Count() == 0)
            {
                return NotFound("No Reviews Found");

            }
            return Ok(ReviewsList);

        }

        [HttpGet("{ID}", Name = "GetreviewByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Review>> GetreviewByIDAsync(int ID)
        {
            if (ID > 1)
            {
                return BadRequest($"invalid {ID}");
            }

            // we retriev full review here ,maybe we  need some of its method to do some logic
            var review = await _reviewService.GetByIDAsync(ID);

            if (review is null)
            {
                return NotFound("No review found");
            }
            else
            {

                return Ok(review);
            }
        }

        [HttpPost(Name = "Addreview")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Review>> AddreviewAsync(Review review)
        {
            if (review == null )

            {
                return BadRequest($"invalid review Data ");
            }


            var reviewID = await _reviewService.AddAsync(review);


            if (reviewID != 0)
            {
                return CreatedAtRoute($"GetreviewByID", reviewID);
            }
            else
                return BadRequest($"Saving Failed  :( ");

        }


        [HttpPut("{ID}", Name = "Udatereview")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Review>> UbdatereviewAsync(int ID, Review Updatedreview)
        {
            if (ID < 1 )
            {
                return BadRequest($"invalid Data ");
            }


            var review = await _reviewService.GetByIDAsync(ID);



            if (review != null)
            {

                Updatedreview.Id = review.Id;

                await _reviewService.UpdateAsync(Updatedreview);
                {
                    return Ok($"review with ID = {ID} Updated Successfully ");
                }

            }
            return BadRequest($"invalid review Data ");

        }


        [HttpDelete("{ID}", Name = "Deletereview")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeletreviewAsync(int ID)
        {

            if (ID < 1)
            {
                return BadRequest("Invalid ID");
            }
            var review = await _reviewService.GetByIDAsync(ID);

            if (review != null)
            {

                if (await _reviewService.DeleteAsync(ID))
                {
                    return Ok($"review with ID = {ID} Deleted Successfully ");
                }

            }
            return BadRequest($" there is NO review with ID = {ID} ");

        }


    }
}
