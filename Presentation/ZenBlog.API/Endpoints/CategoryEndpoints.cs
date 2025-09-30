using MediatR;
using ZenBlog.Application.Features.Categories.Commands.Create;
using ZenBlog.Application.Features.Categories.Queries.GetAllCategories;

namespace ZenBlog.API.Endpoints;

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

        categories.MapPost(string.Empty, async (IMediator mediator, CreateCategoryCommand createCategoryCommand) =>
        {
            var response = await mediator.Send(createCategoryCommand);
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });
    }
}