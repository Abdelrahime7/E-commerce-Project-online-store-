using Application.DTOs.Review;
using AutoMapper;
using Domain.entities;

namespace Application.Mapper.ReviewsProfile
{
    internal class ReviewMapping : Profile
    {
        public void ApplyMapping()
        {
            CreateMap<Review,ReviewDto>();

        }
    }
}
