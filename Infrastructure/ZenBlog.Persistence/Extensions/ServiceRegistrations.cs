using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Options;
using ZenBlog.Domain.Entities;
using ZenBlog.Persistence.Concrete;
using ZenBlog.Persistence.Context;
using ZenBlog.Persistence.Interceptors;

namespace ZenBlog.Persistence.Extensions;

public static class ServiceRegistrations
{
    public static IServiceCollection AddZenBlogPersistence(this IServiceCollection services,
        IConfiguration configuration)
    {
        #region Entity Framework

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
            options.AddInterceptors(new AuditDbContextInterceptor());
            options.UseLazyLoadingProxies();
        });

        services.AddIdentity<AppUser, AppRole>(options => { options.User.RequireUniqueEmail = true; })
            .AddEntityFrameworkStores<AppDbContext>();

        #endregion

        #region Generic Registration

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IJwtService, JwtService>();

        #endregion

        #region JWT Authentication

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
        {
            var jwtTokenOptions = configuration.GetSection(nameof(JwtTokenOptions)).Get<JwtTokenOptions>() ??
                                  throw new InvalidOperationException(
                                      "JWT configuration is missing from appsettings.json");
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ValidIssuer = jwtTokenOptions!.Issuer,
                ValidAudience = jwtTokenOptions.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtTokenOptions.Key!)),
                ClockSkew = TimeSpan.FromSeconds(5)
            };
        });

        #endregion

        return services;
    }
}