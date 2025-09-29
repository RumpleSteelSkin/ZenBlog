using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZenBlog.Domain.Entities;
using ZenBlog.Persistence.Context;

namespace ZenBlog.Persistence.Extensions;

public static class ServiceRegistrations
{
    public static IServiceCollection AddZenBlogPersistence(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
            options.UseLazyLoadingProxies();
        });
        
        services.AddIdentity<AppUser,AppRole>(options =>
        {
            options.User.RequireUniqueEmail = true;
        }).AddEntityFrameworkStores<AppDbContext>();
        
        return services;
    }
}