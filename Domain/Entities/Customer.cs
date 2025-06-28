using Domain.Interface;

namespace Domain.entities;

public class Customer :IEntity
{
    public int Id { get; set; }

    public required Person  Person { get; set; }
    public int Point {  get; set; }
    public int PurchaseHistoryId {  get; set; }
}