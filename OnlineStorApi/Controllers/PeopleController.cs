using Application.Services;
using Domain.entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace OnlineStorApi.Controller
{
    [Route("api/People")]
    [ApiController]
    public class PeopleContoller : ControllerBase
    {
        private readonly PersonService  _personService ;
       
        public PeopleContoller(PersonService personService)
        {
            _personService = personService ;
        }

        [HttpGet("All", Name = "GetAllPeopl")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<IEnumerable<Person>>> AllPeopleAsync()
        {
          
            var PeopleList =await _personService.GettallAsync();
            if (PeopleList.Count() == 0)
            {
                return NotFound("No People Found");

            }
            return Ok(PeopleList);

        }

        [HttpGet("{ID}", Name = "GetPersonByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Person>> GetPersonByIDAsync(int ID)
        {
            if (ID > 1)
            {
                return BadRequest($"invalid {ID}");
            }

            // we retriev full Person here ,maybe we  need some of its method to do some logic
            var Person =await _personService.GetByIDAsync(ID);

            if (Person is null)
            {
                return NotFound("No Person found");
            }
            else
            {
           
                return Ok(Person);
            }
        }

        [HttpPost(Name = "AddPerson")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Person>> AddPersonAsync(Person person)
        {
            if (person == null || string.IsNullOrEmpty(person.FName) || string.IsNullOrEmpty(person.LName))
               
            {
                return BadRequest($"invalid Person Data ");
            }


           var personID= await _personService.AddAsync(person);
            

            if (personID != 0)
            {
                return CreatedAtRoute($"GetPersonByID", personID);
            }
            else
                return BadRequest($"Saving Failed  :( ");

        }


        [HttpPut("{ID}", Name = "UdatePerson")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Person>> UbdatePersonAsync(int ID, Person Updatedperson)
        {
            if (ID<1 || Updatedperson == null || string.IsNullOrEmpty(Updatedperson.FName) || string.IsNullOrEmpty(Updatedperson.LName))
            {
                return BadRequest($"invalid Data ");
            }


            var Person =await _personService.GetByIDAsync(ID);

            

            if (Person != null)
            {

                Updatedperson.Id = Person.Id;

               await _personService.UpdateAsync(Updatedperson);
                {
                    return Ok($"Person with ID = {ID} Updated Successfully ");
                }

            }
            return BadRequest($"invalid Person Data ");

        }


        [HttpDelete("{ID}", Name = "DeletePerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeletPersonAsync(int ID)
        {

            if (ID < 1)
            {
                return BadRequest("Invalid ID");
            }
            var Person =await _personService.GetByIDAsync(ID);

            if (Person != null)
            {

                if (await _personService.DeleteAsync(ID))
                {
                    return Ok($"Person with ID = {ID} Deleted Successfully ");
                }

            }
            return BadRequest($" there is NO Person with ID = {ID} ");

        }




    }
}
