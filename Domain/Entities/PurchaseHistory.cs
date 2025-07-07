using Domain.Interface;

namespace Domain.entities;

public class PurchaseHistory:IEntity
{
    public int  Id { get; set; }
    public int OrderId  { get; set; }
    public int CustomerId { get; set; }
    public  Customer  Customer { get; set; }
    public  Order Order { get; set; }


}