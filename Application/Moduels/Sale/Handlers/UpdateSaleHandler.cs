using AutoMapper;

using Domain.Interface;
using Domain.Interfaces.Generic;
using Application.Moduels.Sale.Commands;
using Application.Moduels.GenericHndlers;
using Application.DTOs.Sale;

namespace Application.Moduels.sale.Handlers
{
    public class UpdateSaleHandler : UpdateHandler<UpdateSaleCommand,SaleDto>
    {
        public UpdateSaleHandler(IMapper mapper, IGenericRepository<IEntity> repository) : base(mapper, repository)
        {
        }

        protected override int GetId(UpdateSaleCommand command) => command.Response.Id;
       
    }





}

