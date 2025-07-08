using Application.DTOs.Customer;
using Application.DTOs.Order;
using MediatR;

namespace Application.Moduels.Order.Commands
{
    public record CreateOrderCommand(OrderDto orderDto) : IRequest<int>;
    public record UpdateOrderCommand(OrderResponse Response) : IRequest<OrderDto>;

}
