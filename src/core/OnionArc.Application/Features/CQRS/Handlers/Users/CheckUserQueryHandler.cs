using MediatR;
using OnionArc.Application.Abstract;
using OnionArc.Application.Dtos.UserDtos;
using OnionArc.Application.Features.CQRS.Queries.Users;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Features.CQRS.Handlers.Users;

public class CheckUserQueryHandler : IRequestHandler<CheckUserQueryRequest, CheckUserResponseDto>
{
    private readonly IRepository<AppUser> _repositoryUser;
    private readonly IRepository<AppRole> _repositoryRole;

    public CheckUserQueryHandler(IRepository<AppUser> repositoryUser, IRepository<AppRole> repositoryRole)
    {
        _repositoryUser = repositoryUser;
        _repositoryRole = repositoryRole;
    }

    public async Task<CheckUserResponseDto> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
    {
        CheckUserResponseDto dto = new();
        var user = await _repositoryUser.GetByFilterAsync(x => x.Username == request.Username && x.Password == request.Password);
        if (user is null)
            dto.IsExist = false;
        else
        {
            dto.IsExist = true;
            dto.Id = user.Id;
            dto.Username = user.Username;
            dto.Role = (await _repositoryRole.GetByFilterAsync(x => x.Id == user.AppRoleId))?.Definition;
        }
        return dto;
    }
}
