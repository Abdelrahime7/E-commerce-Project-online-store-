using Application.DTOs;
using MediatR;


namespace Application.Moduels.Customer.Commands
{
  
        public record CreateCustomerCommand(CustomerDto customerDto) : IRequest<int>;


   
}
