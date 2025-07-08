using Application.DTOs.Customer;
using Application.DTOs.Sale;
using MediatR;


namespace Application.Moduels.Sale.Commands
{
    public record CreateSaleCommand(SaleDto saleDto) : IRequest<int>;
    public record UpdateSaleCommand(SaleResponse Response) : IRequest<SaleDto>;
}
