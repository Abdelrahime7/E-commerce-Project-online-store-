﻿using Domain.Interface;

namespace Domain.entities;

public class Person:IEntity
{
    public int Id {  get; set; }
    public required string FName { get; set; }
    public required string  LName { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }

    public  User ? User { get; set; } 
    public Customer? Customer { get; set; }
}