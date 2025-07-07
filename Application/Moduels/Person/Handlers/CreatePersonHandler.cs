using Application.Interface;
using AutoMapper;

using Domain.Interfaces.Generic;
using Domain.Interface;
using Application.Moduels.Purchase.Commands;


namespace Application.Moduels.Person.Handlers
{
   

    public class CreatePurchaseHandler(CreatePurchaseCommand command  , IMapper mapper, IPersonRepository repository) : CreatHandler(command, mapper, (IGenericRepository<IEntity>)repository)
    {
       

    }




}
