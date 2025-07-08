using Application.Interface;
using AutoMapper;

using Domain.Interface;
using Domain.Interfaces.Generic;
using Application.Moduels.Customer.Commands;
using Application.Moduels.GenericHndlers;

namespace Application.Moduels.Customer.Handlers
{



    public class CreateCustomerHandler : CreatHandler<CreateCustomerCommand>
    {
        public CreateCustomerHandler(IMapper mapper, IGenericRepository<IEntity> repository) : base(mapper, repository)
        {
            
        }

    }





}

