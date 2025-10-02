using MediatR;
using ZenBlog.Application.Features.Users.Commands.Create;

namespace ZenBlog.API.Endpoints;

public static class UserEndpoints
{
    public static void RegisterUserEndpoints(this IEndpointRouteBuilder app)
    {
        var users = app.MapGroup("/users").WithTags("Users");
        users.MapPost("register", async (IMediator mediator, CreateUserCommand createUserCommand) =>
        {
            var response = await mediator.Send(createUserCommand);
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });
    }
}