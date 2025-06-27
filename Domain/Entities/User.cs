namespace Domain.entities;

public class User
{
    public int Id { get; set; }
    public required Person Person { get; set; }
    public string ? UserName  { get; set; }
    public string ? Password { get; set; } 
    public short Permission {  get; set; }
    bool? IsAdmin { get; set; }

    public bool? IsGuest { get; set; }
}