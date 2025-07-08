using AutoMapper;
using Domain.Interfaces.Generic;
using Domain.Interface;
using Application.Moduels.Sale.Commands;
using Application.Moduels.GenericHndlers;


namespace Application.Moduels.Sale.Handlers
{

    public class CreateSaleHandler : CreatHandler<CreateSaleCommand>
    {
        public CreateSaleHandler(IMapper mapper, IGenericRepository<IEntity> repository) : base(mapper, repository)
        {

        }

    }



}
