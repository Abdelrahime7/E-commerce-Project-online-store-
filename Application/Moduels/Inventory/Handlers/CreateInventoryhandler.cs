
using AutoMapper;
using  Application.Moduels.Inventory.Commands;
using Domain.Interface;
using Domain.Interfaces.Generic;
using Application.Moduels.GenericHndlers;

namespace Application.Moduels.Inventory.Handlers
{

    

    public class CreateInventoryHandler : CreatHandler<CreateInventoryCommand>
    {
        public CreateInventoryHandler(IMapper mapper, IGenericRepository<IEntity> repository) : base(mapper, repository)
        {

        }

    }


}

