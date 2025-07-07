using Application.Interface;
using AutoMapper;
using Domain.Interfaces.Generic;
using Domain.Interface;
using Application.Moduels.Purchase.Commands;
using Application.Moduels.GenericHndlers;


namespace Application.Moduels.Purchase.Handlers
{
   

    public class CreatePurchaseHandler(CreatePurchaseCommand command  , IMapper mapper, IPurchaseRepository repository) : CreatHandler(command, mapper, (IGenericRepository<IEntity>)repository)
    {
       

    }




}
