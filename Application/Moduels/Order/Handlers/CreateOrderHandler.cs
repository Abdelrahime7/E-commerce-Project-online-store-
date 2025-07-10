
using AutoMapper;

using Domain.Interface;
using Application.Moduels.GenericHndlers;
using Application.Moduels.Order.Commands;
using Application.Interfaces.Generic;


namespace Application.Moduels.Order.Handlers
{


    public class CreateOrderHandler : CreatHandler<CreateOrderCommand>
    {
        public CreateOrderHandler(IMapper mapper, IGenericRepository<IEntity> repository) : base(mapper, repository)
        {

        }

    }
}
