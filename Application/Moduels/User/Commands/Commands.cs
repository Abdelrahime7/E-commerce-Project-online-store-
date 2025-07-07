using Application.DTOs;
using MediatR;


namespace Application.Moduels.User.Commands
{
    public record CreateUserCommand(UserDto userDto) : IRequest<int>;

}
