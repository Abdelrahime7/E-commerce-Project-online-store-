using Application.Interface;
using AutoMapper;
using Domain.Interfaces.Generic;
using Domain.Interface;
using Application.Moduels.User.Commands;
using Application.Moduels.GenericHndlers;


namespace Application.Moduels.Person.Handlers
{
   

    public class CreateUserHandler(CreateUserCommand command  , IMapper mapper, IUserRepository repository) : CreatHandler(command, mapper, (IGenericRepository<IEntity>)repository)
    {
       

    }




}
