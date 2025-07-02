using Domain.Interface;

namespace Domain.entities;

public class Review:IEntity
{
    public int Id { get; set; }
    public string ? Descreption { get; set; }
    public DateTime Date { get; set; }

    public int CustomerId { get; set; }
    public int ItemID { get; set; }
    public required Customer Customer { get; set; }
    public  required Item Item { get; set; }


}