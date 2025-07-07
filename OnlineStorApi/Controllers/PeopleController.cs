using Application.Moduels.Person.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStorApi.Controller
{
    [Route("api/People")]
    [ApiController]
    public class PeopleContoller : ControllerBase
    {

        private readonly ISender _sender;
        public PeopleContoller(ISender sender)
        {
            _sender = sender;
        }



        [HttpPost(Name = "AddPerson")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> AddPerson(CreatePersonCommand command)
        {
            if (command != null)
            {
                var ID = await _sender.Send(command);
                return CreatedAtRoute($"GetPersonByID", new { Id = ID }, command);
            }
            return BadRequest("Input data is null or invalid.");


        }



    }
}
