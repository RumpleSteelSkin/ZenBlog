using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace ZenBlog.Application.Extensions;

public static class ServiceRegistrations
{
    public static IServiceCollection AddZenBlogApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        return services;
    }
}