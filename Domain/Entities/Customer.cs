namespace Domain.entities;

public class Customer 
{
    public required Person  Person { get; set; }
    public  int CustomerId { get; set; }
    public int Point {  get; set; }
    public int PurchaseHistoryId {  get; set; }



}