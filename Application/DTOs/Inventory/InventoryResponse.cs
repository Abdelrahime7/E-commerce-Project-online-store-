﻿namespace Application.DTOs.Inventory
{
    public record InventoryResponse
    {
      public  int Id { get; set; }
       public int InventoryDevision {  get; set; }
        public int ItemQuantity {  get; set; }
        public  int ItemID { get; set; }
    }


}