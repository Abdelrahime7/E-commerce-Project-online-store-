using Domain.entities;
using Domain.Enums;

namespace Application.DTOs.Order

{
    public record OrderResponse
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public decimal Total { get; set; }
        public int CustomerId { get; set; }

    
    }


}