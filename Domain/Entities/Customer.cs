namespace Domain.entities;

public class Customer : Person
{
    public int Id { get; set; }
    public int Point {  get; set; }
    public int PurchaseHistoryId {  get; set; }
}