using MediatR;
using ZenBlog.Application.Features.Blogs.Commands.Create;
using ZenBlog.Application.Features.Blogs.Commands.Remove;
using ZenBlog.Application.Features.Blogs.Commands.Update;
using ZenBlog.Application.Features.Blogs.Queries.GetAllBlogs;
using ZenBlog.Application.Features.Blogs.Queries.GetBlogById;


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

        blogs.MapGet("{id:guid}", async (IMediator mediator, Guid id) =>
        {
            var response = await mediator.Send(new GetBlogByIdQuery(id));
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        blogs.MapPut("{id:guid}",
            async (IMediator mediator, Guid id, UpdateBlogCommand updateBlogCommand) =>
            {
                if (id != updateBlogCommand.Id) return Results.BadRequest("ID mismatch between URL and body");
                var response = await mediator.Send(updateBlogCommand);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
        
        blogs.MapDelete("{id:guid}", async (IMediator mediator, Guid id) =>
        {
            var response = await mediator.Send(new RemoveBlogCommand(id));
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });
    }
}