﻿using AutoMapper;

using Domain.Interface;
using Application.Moduels.GenericHndlers;
using Application.Moduels.Person.Commands;
using Application.DTOs.Person;
using Application.Interfaces.Generic;

namespace Application.Moduels.Person.Handlers
{
    public class UpdatePersonHandler : UpdateHandler<UpdatePersonCommand, PersonDto>
    {
        public UpdatePersonHandler(IMapper mapper, IGenericRepository<IEntity> repository) : base(mapper, repository)
        {
        }

        protected override int GetId(UpdatePersonCommand command) => command.Response.Id;
       
    }





}

