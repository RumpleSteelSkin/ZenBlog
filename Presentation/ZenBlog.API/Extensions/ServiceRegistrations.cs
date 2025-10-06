using System.Text.Json.Serialization;
using ZenBlog.Application.Extensions;
using ZenBlog.Persistence.Extensions;

namespace ZenBlog.API.Extensions;

public static class ServiceRegistrations
{
    public static IServiceCollection AddZenBlogApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddZenBlogPersistence(configuration);
        services.AddZenBlogApplication();

        #region CORS Services
        
        services.AddCors(opt =>
        {
            opt.AddPolicy("AllowAll", policy =>
                policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

        #endregion

        services.ConfigureHttpJsonOptions(config =>
        {
            config.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });

        services.AddOpenApi();
        return services;
    }
}