using AutoMapper;

using Domain.Interface;
using Domain.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using Application.Moduels.Invoice.Commands;


namespace Application.Moduels.Invoice.Handlers
{

    public class CreateInvoiceHandler : CreatHandler<CreateInvoiceCommand>
    {
        public CreateInvoiceHandler(IMapper mapper, IGenericRepository<IEntity> repository) : base(mapper, repository)
        {

        }

    }





}
