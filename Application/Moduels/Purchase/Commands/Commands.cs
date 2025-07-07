using Application.DTOs;
using MediatR;


namespace Application.Moduels.Purchase.Commands
{
    public record CreatePurchaseCommand(PurchasHistoryDto purhcaseDto) : IRequest<int>;

}
