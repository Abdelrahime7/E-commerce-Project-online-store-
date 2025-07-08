namespace Application.DTOs.Sale
{
    public record SaleDto
    {
        public decimal TotalFees { get; set; }
        public int OrderId { get; set; }
    }

}
