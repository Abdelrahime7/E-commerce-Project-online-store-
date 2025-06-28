using Domain.Interface;

namespace Domain.entities;

public class Inventory:IEntity
{
    public int Id { get; set; }
    public string ?InventoryDevision  { get; set; }
    public int ItemId { get; set; }
    public int ItemQuantity { get; set; }


}