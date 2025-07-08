using AutoMapper;

using Domain.Interfaces.Generic;
using Domain.Interface;
using Application.Moduels.GenericHndlers;
using Application.Moduels.Person.Commands;


namespace Application.Moduels.Person.Handlers
{


    public class CreatePersonHandler : CreatHandler<CreatePersonCommand>
    {
        public CreatePersonHandler(IMapper mapper, IGenericRepository<IEntity> repository) : base(mapper, repository)
        {


        }

    }




}
