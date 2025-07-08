﻿using Application.DTOs.Customer;
using Application.DTOs.Item;
using MediatR;

namespace Application.Moduels.Item.Commands
{
    public record CreateItemCommand(ItemDto itemDto) : IRequest<int>;
    public record UpdateItemCommand(ItemResponse Response) : IRequest<ItemDto>;

}
