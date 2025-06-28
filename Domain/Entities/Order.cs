using Domain.Enums;
using Domain.Interface;

namespace Domain.entities;

public class Order:IEntity
{
    public int Id { get; set; }
    public int InvoiceId { get; set; }
    public OrderStatus Status { get; set; }
    public int  CustomerId {  get; set; }


}