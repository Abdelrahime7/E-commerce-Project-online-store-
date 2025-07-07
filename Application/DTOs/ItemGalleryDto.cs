using Domain.entities;

namespace Application.DTOs
{
    public record ItemGalleryDto
    {
        public int ItemID { get; set; }


        public required string ImageLink { get; set; }

    }


}