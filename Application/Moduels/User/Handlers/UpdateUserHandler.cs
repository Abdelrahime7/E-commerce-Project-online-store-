using AutoMapper;

using Domain.Interface;
using Domain.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using Application.DTOs.User;
using Application.Moduels.User.Commands;

namespace Application.Moduels.User.Handlers
{
    public class UpdateUserHandler : UpdateHandler<UpdateUserCommand, UserDto>
    {
        public UpdateUserHandler(IMapper mapper, IGenericRepository<IEntity> repository) : base(mapper, repository)
        {
        }

        protected override int GetId(UpdateUserCommand command) => command.Response.Id;
       
    }





}

