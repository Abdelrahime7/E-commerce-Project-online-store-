using AutoMapper;

using Domain.Interface;
using Domain.Interfaces.Generic;
using Application.Moduels.Review.Commands;
using Application.Moduels.GenericHndlers;
using Application.DTOs.Review;

namespace Application.Moduels.Review.Handlers
{
    public class UpdateReviewHandler : UpdateHandler<UpdateReviewCommand,ReviewDto>
    {
        public UpdateReviewHandler(IMapper mapper, IGenericRepository<IEntity> repository) : base(mapper, repository)
        {
        }

        protected override int GetId(UpdateReviewCommand command) => command.Response.Id;
       
    }





}

