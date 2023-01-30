using AutoMapper;
using MediatR;
using OnionArc.Application.Abstract;
using OnionArc.Application.Dtos.UserDtos;
using OnionArc.Application.Enums;
using OnionArc.Application.Features.CQRS.Commands.Users;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Features.CQRS.Handlers.Users;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest, CreatedUserDto?>
{
    private readonly IRepository<AppUser> _repository;
    private readonly IMapper _mapper;

    public RegisterUserCommandHandler(IRepository<AppUser> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CreatedUserDto?> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
    {
        AppUser appUser = new()
        {
            AppRoleId = (int)RoleTypes.Member,
            Username = request.Username,
            Password = request.Password
        };
        var user = await _repository.CreateAsync(appUser);
        return _mapper.Map<CreatedUserDto>(user);
    }
}
