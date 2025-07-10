using AutoMapper;

using Domain.Interface;
using Application.Moduels.GenericHndlers;
using Application.Moduels.Order.Commands;
using Application.DTOs.Order;
using Application.Interfaces.Generic;

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

