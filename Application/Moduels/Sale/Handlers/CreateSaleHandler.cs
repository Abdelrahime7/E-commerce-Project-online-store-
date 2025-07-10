using AutoMapper;
using Domain.Interface;
using Application.Moduels.Sale.Commands;
using Application.Moduels.GenericHndlers;
using Application.Interfaces.Generic;


namespace Application.Moduels.Sale.Handlers
{

    public class CreateSaleHandler : CreatHandler<CreateSaleCommand>
    {
        public CreateSaleHandler(IMapper mapper, IGenericRepository<IEntity> repository) : base(mapper, repository)
        {

        }

    }



}
