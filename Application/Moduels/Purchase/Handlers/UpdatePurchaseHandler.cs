using AutoMapper;

using Domain.Interface;
using Application.Moduels.Purchase.Commands;
using Application.Moduels.GenericHndlers;
using Application.DTOs.Purchase;
using Application.Interfaces.Generic;

namespace Application.Moduels.Purchase.Handlers
{
    public class UpdatePurchaseHandler : UpdateHandler<UpdatePurchaseCommand, PurchasHistoryDto>
    {
        public UpdatePurchaseHandler(IMapper mapper, IGenericRepository<IEntity> repository) : base(mapper, repository)
        {
        }

        protected override int GetId(UpdatePurchaseCommand command) => command.Response.Id;
       
    }





}

