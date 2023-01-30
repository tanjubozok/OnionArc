using MediatR;
using OnionArc.Application.Dtos.UserDtos;

namespace OnionArc.Application.Features.CQRS.Commands.Users;

public class RegisterUserCommandRequest : IRequest<CreatedUserDto?>
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}
