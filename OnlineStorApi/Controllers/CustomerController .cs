using Application.Interface;
using Domain.entities;
using Microsoft.AspNetCore.Mvc;
namespace OnlineStorApi.Controllers
{
    [Route("api/Customer")]
    [ApiController]
    public class CustomerContoller( ICustomerRepository customerRepository) : ControllerBase
    {
       
        private readonly ICustomerRepository _customerRepository = customerRepository; 

        [HttpGet("All", Name = "GetAllCustomers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public  async  Task< ActionResult<IEnumerable<Customer>>> AllCustomersAsync()
        {
          

            var CustomerList = await _customerRepository.GetAllAsync();
            if (CustomerList.Any())
            {
                return NotFound("No Customers Found");

            }
            return Ok(CustomerList);

        }

        [HttpGet("{ID}", Name = "GetCustomerByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task< ActionResult<Customer>> GetCustomerByIDAsync(int ID)
        {
            if (ID > 1)
            {
                return BadRequest($"invalid {ID}");
            }

            // we retriev full Customer here ,maybe we  need some of its method to do some logic
            var customer =  await _customerRepository.GetByIDAsync(ID);

            if (customer is null)
            {
                return NotFound("No Student Found");
            }
            else
            {
           
                return Ok(customer);
            }
        }

        [HttpPost(Name = "AddCustomer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Customer>> AddCustomerAsync(Customer customer)
        {
            if (customer == null || string.IsNullOrEmpty(customer.Person.FName) 
                || string.IsNullOrEmpty(customer.Person.LName))
               
            {
                return BadRequest($"invalid Customer Data ");
            }


           var CustomerID = await _customerRepository.AddAsync(customer);
            

            if (CustomerID != 0)
            {
                return CreatedAtRoute($"GetCustomerByID",new {id=customer.Id }, customer);
            }
            else
                return BadRequest($"adding Failed  :( ");

        }


        [HttpPut("{ID}", Name = "UdateCustomer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task< ActionResult<Customer>> UbdateCustomerAsync(int ID, Customer UpdatedCustomer)
        {
            if (ID < 1 || UpdatedCustomer == null || string.IsNullOrEmpty(UpdatedCustomer.Person.FName)
                || string.IsNullOrEmpty(UpdatedCustomer.Person.LName))
            {
                return BadRequest($"invalid Data ");
            }


            var customer = await _customerRepository.GetByIDAsync(ID);

            

            if (customer != null)
            {
                UpdatedCustomer.Id = customer.Id;

                await _customerRepository.UpdateAsync(UpdatedCustomer);
                
                 return Ok($"Student with ID = {ID} Updated Successfully ");
                

            }
            return BadRequest($"invalid Data ");

        }


        [HttpDelete("{ID}", Name = "DeleteCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task< ActionResult> DeletCustomerAsync(int ID)
        {

            if (ID < 1)
            {
                return BadRequest("Invalid ID");
            }
            var customer = await _customerRepository.GetByIDAsync(ID);

            if (customer != null)
            {

                if (await _customerRepository.DeleteAsync(ID))
                {
                    return Ok($"Student with ID = {ID} Deleted Successfully ");
                }

            }
            return BadRequest($" there is NO Student with ID = {ID} ");

        }




    }
}
