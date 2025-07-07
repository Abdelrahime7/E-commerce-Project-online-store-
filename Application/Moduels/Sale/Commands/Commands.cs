using Application.DTOs;
using MediatR;


namespace Application.Moduels.Sale.Commands
{
    public record CreateSaleCommand(SaleDto saleDto) : IRequest<int>;

}
