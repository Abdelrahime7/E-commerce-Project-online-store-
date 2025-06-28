using Domain.Interface;

namespace Domain.entities;

public class Sale:IEntity
{
    public  int Id { get; set; }
    public  int OrderId { get; set; }
    public decimal TotalFee { get; set; }
}