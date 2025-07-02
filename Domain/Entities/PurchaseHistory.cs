using Domain.Interface;

namespace Domain.entities;

public class PurchaseHistory:IEntity
{
    public int  Id { get; set; }
    public int OrderId  { get; set; }
    public int CustomerId { get; set; }
    public required Customer  Customer { get; set; }
    public required Order Order { get; set; }


}