using Scalar.AspNetCore;
using ZenBlog.API.EndpointRegistrations;
using ZenBlog.API.Middlewares;

namespace ZenBlog.API.Extensions;

public static class AppRegistrations
{
    public static void AddZenBlogApiApp(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
            app.UseCors("AllowAll");
        }

        app.UseMiddleware<CustomExceptionHandlingMiddleware>();
        app.UseHttpsRedirection();
        app.MapGroup("/api").RegisterEndpoints();
        app.Run();
    }
}