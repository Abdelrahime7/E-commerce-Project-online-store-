namespace Domain.entities;

public class Inventory
{
    public int Id { get; set; }
    public string ?InventoryDevision  { get; set; }
    public int ItemId { get; set; }
    public int ItemQuantity { get; set; }


}