namespace Domain.entities;

public class ItemGallery
{
    public int  Id  { get; set; }
    public int ItemId { get; set; }
    public required string ImageLink { get; set; }
}