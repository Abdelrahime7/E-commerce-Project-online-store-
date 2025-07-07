﻿using Domain.Interface;

namespace Domain.entities;

public class Invoice :IEntity
{
    public int Id { get; set; }
    public short Quantity   { get; set; }
    public decimal Price { get; set; }
    public DateTime Date { get; set; }
    public int OrderID { get; set; }
    public int ItemID { get; set; }

    public  Item Item  { get; set; }

    public   Order Order { get; set; }
    
}