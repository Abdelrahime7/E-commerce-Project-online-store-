using AutoMapper;
using Domain.Interfaces.Generic;
using Domain.Interface;
using Application.Moduels.User.Commands;
using Application.Moduels.GenericHndlers;


namespace Application.Moduels.User.Handlers
{

    public class CreateUserHandler : CreatHandler<CreateUserCommand>
    {
        public CreateUserHandler(IMapper mapper, IGenericRepository<IEntity> repository) : base(mapper, repository)
        {

        }

    }



}
