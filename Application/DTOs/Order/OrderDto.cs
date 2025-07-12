using Domain.entities;
using Domain.Enums;

namespace Application.DTOs.Order

{
    public record OrderDto
    {

        public OrderStatus Status { get; set; }
        public decimal Total { get; set; }
        public int CustomerId { get; set; }

        public IEnumerable<Domain.entities.Invoice> invoices = [];


    }


}