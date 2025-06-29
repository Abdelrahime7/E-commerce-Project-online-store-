using Application.DTOs;
using AutoMapper;
using Domain.entities;

namespace Application.Mapper.OrdersProfile;

 internal class OrderMapping : Profile
{
   
      public void ApllyMapping()
    {
      CreateMap<Order, OrderDto>();
    }
   

}
