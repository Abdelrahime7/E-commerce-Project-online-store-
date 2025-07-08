using Application.DTOs.Customer;
using Application.DTOs.User;
using MediatR;


namespace Application.Moduels.User.Commands
{
    public record CreateUserCommand(UserDto userDto) : IRequest<int>;
    public record UpdateUserCommand(UserResponse Response) : IRequest<UserDto>;

}
