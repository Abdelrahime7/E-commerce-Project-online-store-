using Domain.Enums;

namespace Domain.entities;

public class Order
{
    public int Id { get; set; }
    public int InvoiceId { get; set; }
    public OrderStatus Status { get; set; }
    public int  CustomerId {  get; set; }


}