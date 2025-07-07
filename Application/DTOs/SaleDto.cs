    namespace Application.DTOs
{
    public record SaleDto
    {
        public decimal TotalFees { get; set; }
        public int OrderId { get; set; }
    }

}
