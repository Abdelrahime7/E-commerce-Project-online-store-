using AutoMapper;

using Domain.Interface;
using Domain.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using Application.Moduels.Item.Commands;
using Application.DTOs.Item;

namespace Application.Moduels.Item.Handlers
{
    public class UpdateItemHandler : UpdateHandler<UpdateItemCommand, ItemDto>
    {
        public UpdateItemHandler(IMapper mapper, IGenericRepository<IEntity> repository) : base(mapper, repository)
        {
        }

        protected override int GetId(UpdateItemCommand command) => command.Response.Id;
       
    }





}

