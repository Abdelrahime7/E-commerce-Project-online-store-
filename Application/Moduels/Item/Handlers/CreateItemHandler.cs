
using Application.Moduels.Item.Commands;
using Application.Moduels.GenericHndlers;
using AutoMapper;
using Domain.Interface;
using Domain.Interfaces.Generic;


namespace Application.Moduels.Item.Handlers
{


    public class CreateItemHandler : CreatHandler<CreateItemCommand>
    {
        public CreateItemHandler(IMapper mapper, IGenericRepository<IEntity> repository) : base(mapper, repository)
        {

        }

    }





}
