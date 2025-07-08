﻿using Domain.entities;

namespace Application.DTOs.ItemGallery
{
    public record ItemGalleryResponse
    {
        public int Id { get; set; }
        public int ItemID { get; set; }


        public required string ImageLink { get; set; }

    }


}