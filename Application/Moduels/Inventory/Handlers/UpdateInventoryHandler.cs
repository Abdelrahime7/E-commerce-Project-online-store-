using AutoMapper;

using Domain.Interface;
using Application.Moduels.Inventory.Commands;
using Application.Moduels.GenericHndlers;
using Application.DTOs.Inventory;
using Application.Interfaces.Generic;

namespace Application.Moduels.Inventory.Handlers
{
    public class UpdateInventoryHandler : UpdateHandler<UpdateInventoryCommand, InventoryDto>
    {
        public UpdateInventoryHandler(IMapper mapper, IGenericRepository<IEntity> repository) : base(mapper, repository)
        {
        }

        protected override int GetId(UpdateInventoryCommand command) => command.Response.Id;
       
    }





}

