using AutoMapper;
using Domain.Interfaces.Generic;
using Domain.Interface;
using Application.Moduels.Purchase.Commands;
using Application.Moduels.GenericHndlers;


namespace Application.Moduels.Purchase.Handlers
{


    public class CreatePurchaseHandler : CreatHandler<CreatePurchaseCommand>
    {
        public CreatePurchaseHandler(IMapper mapper, IGenericRepository<IEntity> repository) : base(mapper, repository)
        {

        }

    }




}
