using MediatR;
using ZenBlog.Application.Features.Categories.Queries.GetAllCategories;

namespace ZenBlog.API.Endpoints;

public static class CategoryEndpoints
{
    public static void RegisterCategoryEndpoints(this IEndpointRouteBuilder app)
    {
        var categories = app.MapGroup("/categories").WithTags("Categories");

        categories.MapGet("", async (IMediator mediator) =>
        {
            var response = await mediator.Send(new GetAllCategoriesQuery());
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });
    }
}