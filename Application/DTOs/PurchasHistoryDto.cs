using Domain.entities;

namespace Application.DTOs
{
    public record PurchasHistoryDto
    {
        
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        
    }

}
