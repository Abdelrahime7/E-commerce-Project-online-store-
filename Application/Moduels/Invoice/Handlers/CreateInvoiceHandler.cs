using AutoMapper;

using Domain.Interface;
using Application.Moduels.GenericHndlers;
using Application.Moduels.Invoice.Commands;
using Application.Interfaces.Generic;


namespace Application.Moduels.Invoice.Handlers
{

    public class CreateInvoiceHandler : CreatHandler<CreateInvoiceCommand>
    {
        public CreateInvoiceHandler(IMapper mapper, IGenericRepository<IEntity> repository) : base(mapper, repository)
        {

        }

    }





}
