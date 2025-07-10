
using AutoMapper;
using Domain.Interface;
using Application.Moduels.Review.Commands;
using Application.Moduels.GenericHndlers;
using Application.Interfaces.Generic;


namespace Application.Moduels.Review.Handlers
{


    public class CreateReviewHandler : CreatHandler<CreateReviewCommand>
    {
        public CreateReviewHandler(IMapper mapper, IGenericRepository<IEntity> repository) : base(mapper, repository)
        {

        }

    }





}
