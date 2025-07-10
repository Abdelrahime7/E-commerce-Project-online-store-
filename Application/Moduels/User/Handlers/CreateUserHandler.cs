using AutoMapper;
using Domain.Interface;
using Application.Moduels.User.Commands;
using Application.Moduels.GenericHndlers;
using Application.Interfaces.Generic;


namespace Application.Moduels.User.Handlers
{

    public class CreateUserHandler : CreatHandler<CreateUserCommand>
    {
        public CreateUserHandler(IMapper mapper, IGenericRepository<IEntity> repository) : base(mapper, repository)
        {

        }

    }



}
