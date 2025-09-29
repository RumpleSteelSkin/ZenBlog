using Scalar.AspNetCore;
using ZenBlog.API.Endpoints.Registrations;

namespace ZenBlog.API.Extensions;

public static class AppRegistrations
{
    public static void AddZenBlogApiApp(this WebApplication app)
    {
        app.MapGroup("/api").RegisterEndpoints();
        
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
        }

        app.UseHttpsRedirection();

        app.Run();
    }
}