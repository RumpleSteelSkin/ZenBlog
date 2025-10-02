namespace ZenBlog.API.Endpoints.Registrations;

public static class EndpointRegistrations
{
    public static void RegisterEndpoints(this IEndpointRouteBuilder app)
    {
        app.RegisterCategoryEndpoints();
        app.RegisterBlogEndpoints();
    }
}