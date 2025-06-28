using Application.Interface;
using Domain.entities;
using Microsoft.AspNetCore.Mvc;
using OnlineStorAccess.Services;

namespace OnlineStorApi.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController(UserService usersService ) : ControllerBase
    {


        private readonly UserService _usersService = usersService;

        [HttpGet("All", Name = "GetAllPeopl")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<IEnumerable<User>>> AllUsersAsync()
        {
         
           
            var UsersList = await _usersService.GettallAsync();
            if (UsersList.Any())
            {
                return NotFound("No Users Found");

            }
            return Ok(UsersList);

        }

        [HttpGet("{ID}", Name = "GetUserByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<User>> GetUserByIDAsync(int ID)
        {
            if (ID > 1)
            {
                return BadRequest($"invalid {ID}");
            }

            // we retriev full User here ,maybe we  need some of its method to do some logic
            var User = await _usersService.GetByIDAsync(ID);

            if (User is null)
            {
                return NotFound("No User found");
            }
            else
            {

                return Ok(User);
            }
        }

        [HttpPost(Name = "AddUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<User>> AddUserAsync(User User)
        {
            if (User == null || string.IsNullOrEmpty(User.Person.FName))

            {
                return BadRequest($"invalid User Data ");
            }


            var UserID = await _usersService.AddAsync(User);


            if (UserID != 0)
            {
                return CreatedAtRoute($"GetUserByID", UserID);
            }
            else
                return BadRequest($"Saving Failed  :( ");

        }


        [HttpPut("{ID}", Name = "UdateUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<User>> UbdateUserAsync(int ID, User UpdatedUser)
        {
            if (ID < 1 || UpdatedUser == null)
            {
                return BadRequest($"invalid Data ");
            }


            var User = await _usersService.GetByIDAsync(ID);



            if (User != null)
            {

                UpdatedUser.Id = User.Id;

                await _usersService.UpdateAsync(UpdatedUser);
                {
                    return Ok($"User with ID = {ID} Updated Successfully ");
                }

            }
            return BadRequest($"invalid User Data ");

        }


        [HttpDelete("{ID}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeletUserAsync(int ID)
        {

            if (ID < 1)
            {
                return BadRequest("Invalid ID");
            }
            var User = await _usersService.GetByIDAsync(ID);

            if (User != null)
            {

                if (await _usersService.DeleteAsync(ID))
                {
                    return Ok($"User with ID = {ID} Deleted Successfully ");
                }

            }
            return BadRequest($" there is NO User with ID = {ID} ");

        }



    }
}
