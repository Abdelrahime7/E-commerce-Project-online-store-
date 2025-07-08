﻿using Application.DTOs.Customer;
using Application.DTOs.Review;
using MediatR;


namespace Application.Moduels.Review.Commands
{
    public record CreateReviewCommand(ReviewDto reviewDto) : IRequest<int>;
    public record UpdateReviewCommand(ReviewResponse Response) : IRequest<ReviewDto>;

}
