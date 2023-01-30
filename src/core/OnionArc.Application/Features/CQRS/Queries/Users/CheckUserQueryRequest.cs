using MediatR;
using OnionArc.Application.Dtos.UserDtos;

namespace OnionArc.Application.Features.CQRS.Queries.Users;

public class CheckUserQueryRequest : IRequest<CheckUserResponseDto>
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}
