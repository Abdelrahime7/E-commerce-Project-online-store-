
using AutoMapper;
using Application.Moduels.Inventory.Commands;
using Domain.Interface;
using Application.Moduels.GenericHndlers;
using Application.Interfaces.Generic;

namespace Application.Moduels.Inventory.Handlers
{

    

    public class CreateInventoryHandler : CreatHandler<CreateInventoryCommand>
    {
        public CreateInventoryHandler(IMapper mapper, IGenericRepository<IEntity> repository) : base(mapper, repository)
        {

        }

    }


}

