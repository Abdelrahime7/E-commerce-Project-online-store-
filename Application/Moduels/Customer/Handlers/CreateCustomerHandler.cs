using Application.Interface;
using AutoMapper;

using Domain.Interface;
using Domain.Interfaces.Generic;
using Application.Moduels.Customer.Commands;

namespace Application.Moduels.Customer.Handlers
{

    /* public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, int>
     {
         private readonly IMapper _mapper;
         private readonly ICustomerRepository _customerRepository;

         public CreateCustomerHandler(IMapper mapper, ICustomerRepository customerRepository)
         {
             _customerRepository = customerRepository;
             _mapper = mapper;

         }

         public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
         {


            var Customer =_mapper.Map<Domain.entities.Customer>(request);
             await _customerRepository.AddAsync(Customer);
             return Customer.Id;

         }


     }*/


    public class CreateCustomerHandler(CreateCustomerCommand command, IMapper mapper, ICustomerRepository repository) : CreatHandler(command, mapper, (IGenericRepository<IEntity>)repository)
    {


    }

}

