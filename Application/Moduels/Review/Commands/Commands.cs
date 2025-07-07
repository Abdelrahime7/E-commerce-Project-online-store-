using Application.DTOs;
using MediatR;


namespace Application.Moduels.Review.Commands
{
    public record CreateReviewCommand(ReviewDto reviewDto) : IRequest<int>;

}
