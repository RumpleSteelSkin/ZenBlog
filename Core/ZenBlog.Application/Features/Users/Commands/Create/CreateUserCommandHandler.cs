using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ZenBlog.Application.Base;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Users.Commands.Create;

public class CreateUserCommandHandler(UserManager<AppUser> userManager, IMapper mapper)
    : IRequestHandler<CreateUserCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<AppUser>(request);
        var result = await userManager.CreateAsync(user, request.Password ?? string.Empty);
        return !result.Succeeded ? BaseResult<object>.Fail() : BaseResult<object>.Success(result);
    }
}