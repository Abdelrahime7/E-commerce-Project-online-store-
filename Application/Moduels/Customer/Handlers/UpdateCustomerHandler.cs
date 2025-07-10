using AutoMapper;

using Domain.Interface;
using Application.Moduels.Customer.Commands;
using Application.Moduels.GenericHndlers;
using Application.DTOs.Customer;
using Application.Interfaces.Generic;

namespace Application.Moduels.Customer.Handlers
{
    public class UpdateCustomerHandler : UpdateHandler<UpdateCustomerCommand,CustomerDto>
    {
        public UpdateCustomerHandler(IMapper mapper, IGenericRepository<IEntity> repository) : base(mapper, repository)
        {
        }

        protected override int GetId(UpdateCustomerCommand command) => command.Response.ID;
       
    }





}

