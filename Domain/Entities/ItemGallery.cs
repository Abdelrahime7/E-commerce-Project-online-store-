using Domain.Interface;

namespace Domain.entities;

public class ItemGallery:IEntity
{
    public int  Id  { get; set; }
    public int ItemId { get; set; }
    public required string ImageLink { get; set; }


}