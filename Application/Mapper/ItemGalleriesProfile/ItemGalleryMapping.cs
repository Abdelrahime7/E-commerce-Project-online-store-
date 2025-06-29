using Application.DTOs;
using AutoMapper;
using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper.ItemGalleriesProfile
{
    internal class ItemGalleryMapping : Profile
    {
        public void ApplyMapping()
        {
            CreateMap<Customer, CustomerDto>();

        }
    }
}
