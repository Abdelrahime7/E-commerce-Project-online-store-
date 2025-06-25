namespace Domain.entities;

public class Sale
{
    public  int Id { get; set; }
    public  int OrderId { get; set; }
    public decimal TotalAmount { get; set; } 
}