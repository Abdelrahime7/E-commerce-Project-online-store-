using Application.Interface;
using AutoMapper;
using Application.Moduels.Person.Commands;
using Domain.Interfaces.Generic;
using Domain.Interface;
using Application.DTOs;
using Application.Moduels.Review.Commands;


namespace Application.Moduels.Review.Handlers
{
   

    public class CreateReviewHandler(CreateReviewCommand command  , IMapper mapper, IReviewRepository repository) : CreatHandler(command, mapper, (IGenericRepository<IEntity>)repository)
    {
       

    }




}
