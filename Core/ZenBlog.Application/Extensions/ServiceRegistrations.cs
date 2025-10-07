using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZenBlog.Application.Options;
using ZenBlog.Application.Pipelines;

namespace ZenBlog.Application.Extensions;

public static class ServiceRegistrations
{
    public static IServiceCollection AddZenBlogApplication(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            opt.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.Configure<JwtTokenOptions>(configuration.GetSection(nameof(JwtTokenOptions)));
        
        return services;
    }
}