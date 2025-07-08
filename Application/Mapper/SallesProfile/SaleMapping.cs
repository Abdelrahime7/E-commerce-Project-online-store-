using Application.DTOs.Sale;
using AutoMapper;
using Domain.entities;

namespace Application.Mapper.SallesProfile
{
    internal class SaleMapping :Profile
    {
        public void ApplyMapping()
        {
            CreateMap<Sale, SaleDto>();

        }
    }
}
