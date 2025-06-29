using Domain.entities;
using AutoMapper;
using Application.DTOs;
namespace Application.Mapper.InventorysProfile;

internal class InventoryMapping : Profile
{
    public void ApplyMapping()
    {
        CreateMap<Customer, CustomerDto>();

    }
}
