using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.ContactInfos.Commands.Create;
using ZenBlog.Application.Features.ContactInfos.Commands.Remove;
using ZenBlog.Application.Features.ContactInfos.Commands.Update;
using ZenBlog.Application.Features.ContactInfos.Queries.GetAllContactInfos;
using ZenBlog.Application.Features.ContactInfos.Queries.GetContactInfoById;

namespace ZenBlog.Application.Features.ContactInfos.Endpoints;

public static class ContactInfoEndpoints
{
    public static void RegisterContactInfoEndpoints(this IEndpointRouteBuilder app)
    {
        var contactInfos = app.MapGroup("/contactinfos").WithTags("ContactInfos");

        contactInfos.MapGet(string.Empty, async (IMediator mediator) =>
        {
            var response = await mediator.Send(new GetAllContactInfosQuery());
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        }).AllowAnonymous();

        contactInfos.MapGet("{id:guid}", async (IMediator mediator, Guid id) =>
        {
            var response = await mediator.Send(new GetContactInfoByIdQuery(id));
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        }).AllowAnonymous();

        contactInfos.MapPost(string.Empty, async (IMediator mediator, CreateContactInfoCommand command) =>
        {
            var response = await mediator.Send(command);
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        contactInfos.MapPut("{id:guid}", async (IMediator mediator, Guid id, UpdateContactInfoCommand command) =>
        {
            if (id != command.Id) return Results.BadRequest("ID mismatch between URL and body");
            var response = await mediator.Send(command);
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        contactInfos.MapDelete("{id:guid}", async (IMediator mediator, Guid id) =>
        {
            var response = await mediator.Send(new RemoveContactInfoCommand(id));
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });
    }
}