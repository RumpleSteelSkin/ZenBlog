using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.Categories.Commands.Create;
using ZenBlog.Application.Features.Categories.Commands.Remove;
using ZenBlog.Application.Features.Categories.Commands.Update;
using ZenBlog.Application.Features.Categories.Queries.GetAllCategories;
using ZenBlog.Application.Features.Categories.Queries.GetCategoryById;

namespace ZenBlog.Application.Features.Categories.Endpoints;

public static class CategoryEndpoints
{
    public static void RegisterCategoryEndpoints(this IEndpointRouteBuilder app)
    {
        var categories = app.MapGroup("/categories").WithTags("Categories");

        categories.MapGet(string.Empty, async (IMediator mediator) =>
        {
            var response = await mediator.Send(new GetAllCategoriesQuery());
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        categories.MapGet("{id:guid}", async (IMediator mediator, Guid id) =>
        {
            var response = await mediator.Send(new GetCategoryByIdQuery(id));
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        categories.MapPost(string.Empty, async (IMediator mediator, CreateCategoryCommand createCategoryCommand) =>
        {
            var response = await mediator.Send(createCategoryCommand);
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        categories.MapPut("{id:guid}",
            async (IMediator mediator, Guid id, UpdateCategoryCommand updateCategoryCommand) =>
            {
                if (id != updateCategoryCommand.Id) return Results.BadRequest("ID mismatch between URL and body");
                var response = await mediator.Send(updateCategoryCommand);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

        categories.MapDelete("{id:guid}", async (IMediator mediator, Guid id) =>
        {
            var response = await mediator.Send(new RemoveCategoryCommand(id));
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });
    }
}