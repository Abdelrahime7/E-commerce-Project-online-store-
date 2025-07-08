using Domain.entities;

namespace Application.DTOs.Purchase
{
    public record PurchasHistoryResponse
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        
    }

}
