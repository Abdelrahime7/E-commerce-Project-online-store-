using Application.Services;
using Domain.entities;
using Microsoft.AspNetCore.Mvc;
using OnlineStorAccess.Services;
using System.Threading.Tasks;

namespace OnlineStorApi.Controllers
{
    [Route("api/Customer")]
    [ApiController]
    public class CustomerContoller : ControllerBase
    {
        private readonly CustomerService  _customerService ;
       
        public CustomerContoller(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("All", Name = "GetAllCustomers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public  async  Task< ActionResult<IEnumerable<Customer>>> AllCustomersAsync()
        {
          
            var CustomerList = await _customerService.GetAllAsync();
            if (CustomerList.Count() == 0)
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
            var customer =  await _customerService.GetByIDAsync(ID);

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
            if (customer == null || string.IsNullOrEmpty(customer.FName) 
                || string.IsNullOrEmpty(customer.LName))
               
            {
                return BadRequest($"invalid Customer Data ");
            }


           var CustomerID = await _customerService.AddAsync(customer);
            

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
            if (ID<1 || UpdatedCustomer == null || string.IsNullOrEmpty(UpdatedCustomer.FName)
                || string.IsNullOrEmpty(UpdatedCustomer.LName))
            {
                return BadRequest($"invalid Data ");
            }


            var customer = await _customerService.GetByIDAsync(ID);

            

            if (customer != null)
            {
                UpdatedCustomer.Id = customer.Id;

                await _customerService.UpdateAsync(UpdatedCustomer);
                
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
            var customer = await _customerService.GetByIDAsync(ID);

            if (customer != null)
            {

                if (await _customerService.DeleteAsync(ID))
                {
                    return Ok($"Student with ID = {ID} Deleted Successfully ");
                }

            }
            return BadRequest($" there is NO Student with ID = {ID} ");

        }




    }
}
