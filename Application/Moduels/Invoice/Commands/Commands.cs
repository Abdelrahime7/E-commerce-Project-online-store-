using Application.DTOs;
using MediatR;


namespace Application.Moduels.Invoice.Commands
{
    public record CreateInvoiceCommand(InvoiceDto invoiceDto) : IRequest<int>;

}
