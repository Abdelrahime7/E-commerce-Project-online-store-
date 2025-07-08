﻿using Application.DTOs.Customer;
using Application.DTOs.Purchase;
using MediatR;


namespace Application.Moduels.Purchase.Commands
{
    public record CreatePurchaseCommand(PurchasHistoryDto purhcaseDto) : IRequest<int>;
    public record UpdatePurchaseCommand(PurchasHistoryResponse Response) : IRequest<PurchasHistoryDto>;

}
