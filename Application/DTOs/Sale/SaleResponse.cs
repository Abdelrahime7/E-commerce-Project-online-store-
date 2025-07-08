namespace Application.DTOs.Sale
{
    public record SaleResponse
    {
        public string Id { get; set; }
        public decimal TotalFees { get; set; }
        public int OrderId { get; set; }
    }

}
