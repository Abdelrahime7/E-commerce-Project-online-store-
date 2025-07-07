using Application.DTOs;
using Application.Interface;
using Application.Moduels.Customer.Commands;
using Domain.entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace OnlineStorApi.Controllers
{
    [Route("api/Customers")]
    [ApiController]
    public class CustomerContoller : ControllerBase
    {
        private readonly ISender _sender;
        public CustomerContoller(ISender sender)
        {
            _sender = sender;
        }



        [HttpPost(Name = "AddCustomer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task< ActionResult< int>> AddCustomer(CreateCustomerCommand command)
        {
            if (command !=null)
            {
                var ID = await _sender.Send(command);
                return CreatedAtRoute($"GetCustomerByID", new { Id = ID }, command);
            }
            return BadRequest("Input data is null or invalid.");


        }






    }
}
