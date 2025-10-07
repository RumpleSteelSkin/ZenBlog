using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.Users.Commands.Create;
using ZenBlog.Application.Features.Users.Queries.LoginUser;

namespace ZenBlog.Application.Features.Users.Endpoints;

public static class UserEndpoints
{
    public static void RegisterUserEndpoints(this IEndpointRouteBuilder app)
    {
        var users = app.MapGroup("/users").WithTags("Users").AllowAnonymous();
        users.MapPost("register", async (IMediator mediator, CreateUserCommand createUserCommand) =>
        {
            var response = await mediator.Send(createUserCommand);
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        users.MapPost("login", async (IMediator mediator, LoginUserQuery command) =>
        {
            var response = await mediator.Send(command);
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });
    }
}