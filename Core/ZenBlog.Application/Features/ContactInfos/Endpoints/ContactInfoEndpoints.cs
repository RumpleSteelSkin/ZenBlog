using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.ContactInfos.Queries.GetAllContactInfos;
using ZenBlog.Application.Features.ContactInfos.Queries.GetContactInfoById;

namespace ZenBlog.Application.Features.ContactInfos.Endpoints;

public static class ContactInfoEndpoints
{
    public static void RegisterContactInfoEndpoints(this IEndpointRouteBuilder app)
    {
        var users = app.MapGroup("/contactinfos").WithTags("ContactInfos");

        users.MapGet(string.Empty, async (IMediator mediator) =>
        {
            var response = await mediator.Send(new GetAllContactInfosQuery());
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        users.MapGet("{id:guid}", async (IMediator mediator, Guid id) =>
        {
            var response = await mediator.Send(new GetContactInfoByIdQuery(id));
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });
        
        
    }
}