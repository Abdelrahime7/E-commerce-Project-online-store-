namespace Domain.entities;

public class PurchaseHistory
{
    public int  Id { get; set; }
    public int OrderId  { get; set; }
    public int CustomerId { get; set; }
}