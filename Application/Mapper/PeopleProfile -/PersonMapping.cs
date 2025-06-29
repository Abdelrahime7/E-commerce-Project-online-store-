using Application.DTOs;
using AutoMapper;
using Domain.entities;


namespace Application.Mapper.PeopleProfile; 

internal class PersonMapping : Profile
{
    public void ApplyMapping()
    {
        CreateMap<Person, PersonDto>();

    }
}
