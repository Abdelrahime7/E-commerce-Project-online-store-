using AutoMapper;
using Domain.Interface;
using Application.Moduels.GenericHndlers;
using Application.Moduels.Person.Commands;
using Application.Interfaces.Generic;


namespace Application.Moduels.Person.Handlers
{


    public class CreatePersonHandler : CreatHandler<CreatePersonCommand>
    {
        public CreatePersonHandler(IMapper mapper, IGenericRepository<IEntity> repository) : base(mapper, repository)
        {


        }

    }




}
