using AutoMapper;

using Domain.Interface;
using Domain.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using Application.Moduels.Order.Commands;
using Application.DTOs.Order;

namespace Application.Moduels.Order.Handlers
{
    public class UpdateOrderHandler : UpdateHandler<UpdateOrderCommand, OrderDto>
    {
        public UpdateOrderHandler(IMapper mapper, IGenericRepository<IEntity> repository) : base(mapper, repository)
        {
        }

        protected override int GetId(UpdateOrderCommand command) => command.Response.Id;
       
    }





}

