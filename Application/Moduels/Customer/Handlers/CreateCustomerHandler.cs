﻿using AutoMapper;
using Application.Moduels.Customer.Commands;
using MediatR;
using Application.Interfaces.Specific;
namespace Application.Moduels.Customer.Handlers
{

    public  class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand,int>
    

    {


        private readonly IMapper _mapper;
        private readonly ICustomerUnitOfWork _unitOfWork;


        protected CreateCustomerHandler(IMapper mapper, ICustomerUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var person = _mapper.Map<Domain.entities.Person>(request);
            var customer = _mapper.Map<Domain.entities.Customer>(request);

            await _unitOfWork.PersonRepository.AddAsync(person);
            customer.Person = person;         
            customer.PersonID = person.Id;    
            await _unitOfWork.CustomerRepository.AddAsync(customer);

            await _unitOfWork.SaveAsync();    
            return customer.Id;


        }
    }




}

