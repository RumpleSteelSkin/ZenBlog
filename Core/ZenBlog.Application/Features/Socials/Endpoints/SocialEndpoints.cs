using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.Socials.Commands.Create;
using ZenBlog.Application.Features.Socials.Commands.Remove;
using ZenBlog.Application.Features.Socials.Commands.Update;
using ZenBlog.Application.Features.Socials.Queries.GetAllSocials;
using ZenBlog.Application.Features.Socials.Queries.GetSocialById;

namespace ZenBlog.Application.Features.Socials.Endpoints;

public static class SocialEndpoints
{
    public static void RegisterSocialEndpoints(this IEndpointRouteBuilder app)
    {
        var socials = app.MapGroup("/socials").WithTags("Socials");

        socials.MapPost(string.Empty, async (IMediator mediator, CreateSocialCommand command) =>
        {
            var response = await mediator.Send(command);
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        socials.MapGet(string.Empty, async (IMediator mediator) =>
        {
            var response = await mediator.Send(new GetAllSocialsQuery());
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        }).AllowAnonymous();

        socials.MapGet("{id:guid}", async (IMediator mediator, Guid id) =>
        {
            var response = await mediator.Send(new GetSocialByIdQuery(id));
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        }).AllowAnonymous();

        socials.MapDelete("{id:guid}", async (IMediator mediator, Guid id) =>
        {
            var response = await mediator.Send(new RemoveSocialCommand(id));
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        socials.MapPut("{id:guid}", async (IMediator mediator, Guid id, UpdateSocialCommand command) =>
        {
            var response = await mediator.Send(command);
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });
    }
}