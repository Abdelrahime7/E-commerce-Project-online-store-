namespace Application.DTOs
{
    public record InventoryDto
    {
       public int InventoryDevision {  get; set; }
        public int ItemQuantity {  get; set; }
        public  int ItemID { get; set; }
    }


}