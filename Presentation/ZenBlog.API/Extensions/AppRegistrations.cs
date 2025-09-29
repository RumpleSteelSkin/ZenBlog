namespace ZenBlog.API.Extensions;

public static class AppRegistrations
{
    public static void AddZenBlogApiApp(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.Run();

    }
}