using Domain.entities;
using AutoMapper;
using Application.DTOs.User;

namespace Application.Mapper.UsersProfile
{
    internal class UserMapping:Profile
    {

        public void ApplyMapping()
        {
            CreateMap<User, UserDto>();

        }
    }
}
