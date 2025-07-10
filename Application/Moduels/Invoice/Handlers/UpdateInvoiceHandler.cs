using AutoMapper;

using Domain.Interface;
using Application.Moduels.GenericHndlers;
using Application.Moduels.Invoice.Commands;
using Application.DTOs.Invoice;
using Application.Interfaces.Generic;

namespace Application.Moduels.Invoice.Handlers
{
    public class UpdateInvoiceHandler : UpdateHandler<UpdateInvoiceCommand, InvoiceDto>
    {
        public UpdateInvoiceHandler(IMapper mapper, IGenericRepository<IEntity> repository) : base(mapper, repository)
        {
        }

        protected override int GetId(UpdateInvoiceCommand command) => command.Response.Id;
       
    }





}

