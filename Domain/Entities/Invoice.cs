using Domain.Interface;

namespace Domain.entities;

public class Invoice :IEntity
{
    public int Id { get; set; }
    public  int ItemId { get; set; }
    public short Quantity   { get; set; }
    public decimal Price { get; set; }
    public decimal Total {  get; set; }
    public DateTime Date { get; set; }
}