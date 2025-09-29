using ZenBlog.Application.Extensions;
using ZenBlog.Persistence.Extensions;

namespace ZenBlog.API.Extensions;

public static class ServiceRegistrations
{
    public static IServiceCollection AddZenBlogApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOpenApi();
        services.AddZenBlogPersistence(configuration);
        services.AddZenBlogApplication();
        return services;
    }
}