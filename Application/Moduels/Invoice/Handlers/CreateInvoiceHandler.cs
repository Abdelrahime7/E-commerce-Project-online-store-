using Application.DTOs;
using Application.Interface;
using AutoMapper;
using MediatR;
using Application.Moduels.ItemGallery.Commands;
using Application.Moduels.Item.Commands;
using Application.Moduels.Customer.Commands;
using Domain.Interface;
using Domain.Interfaces.Generic;


namespace Application.Moduels.Invoice.Handlers
{
    /*  public class CreateOrderHandler : IRequestHandler<CreateInvoiceCommand, int>
      {
          private readonly IMapper _mapper;
          private readonly IInvoiceRepository _invoiceRepository ;


          public CreateOrderHandler(IMapper mapper, IInvoiceRepository invoiceRepository)
          {
              _invoiceRepository = invoiceRepository;
              _mapper = mapper;
          }

          public  async Task <int> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
          {
              //var Customer = new Domain.entities.Customer{Point= request.Point,PersonID= request.PersonID };
              var Invoice = _mapper.Map<Domain.entities.Invoice>(request);
              await _invoiceRepository.AddAsync(Invoice); 
              return Invoice.Id;

          }
      }*/

    public class CreateInvoiceHandler(CreateInvoiceCommand command, IMapper mapper, IInvoiceRepository repository) : CreatHandler(command, mapper, (IGenericRepository<IEntity>)repository)
    {


    }
}
