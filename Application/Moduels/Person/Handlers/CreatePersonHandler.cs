using Application.Interface;
using AutoMapper;

using Domain.Interfaces.Generic;
using Domain.Interface;
using Application.Moduels.Purchase.Commands;
using Application.Moduels.GenericHndlers;
using Application.Moduels.Person.Commands;


namespace Application.Moduels.Person.Handlers
{
   

    public class CreatePersonHandler(CreatePersonCommand command  , IMapper mapper, IPersonRepository repository) : CreatHandler(command, mapper, (IGenericRepository<IEntity>)repository)
    {
       

    }




}
