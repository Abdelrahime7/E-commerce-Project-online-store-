using Application.DTOs;
using AutoMapper;
using Domain.entities;

namespace Application.Mapper.ItemsProfile
{
    internal class ItemMapping :Profile
    {
        public void ApplyMapping()
        {
            CreateMap<Item,ItemDto>();

        }
    }
}
