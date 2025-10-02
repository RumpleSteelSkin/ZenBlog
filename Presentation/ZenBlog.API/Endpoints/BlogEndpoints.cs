using MediatR;
using ZenBlog.Application.Features.Blogs.Commands.Create;
using ZenBlog.Application.Features.Blogs.Queries.GetAllBlogs;


namespace ZenBlog.API.Endpoints;

public static class BlogEndpoints
{
    public static void RegisterBlogEndpoints(this IEndpointRouteBuilder app)
    {
        var blogs = app.MapGroup("/blogs").WithTags("Blogs");

        blogs.MapGet(string.Empty, async (IMediator mediator) =>
        {
            var response = await mediator.Send(new GetAllBlogsQuery());
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        blogs.MapPost(string.Empty, async (IMediator mediator, CreateBlogCommand createBlogCommand) =>
        {
            var response = await mediator.Send(createBlogCommand);
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });
    }
}