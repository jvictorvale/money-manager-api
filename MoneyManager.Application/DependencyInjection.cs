using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoneyManager.Application.Configurations;
using MoneyManager.Application.Contracts;
using MoneyManager.Application.Notifications;
using MoneyManager.Application.Services;
using MoneyManager.Domain.Entities;
using MoneyManager.Infra.Data;
using ScottBrady91.AspNetCore.Identity;

namespace MoneyManager.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration,
        WebApplicationBuilder builder)
    {
        services.ServicesDependencies(builder);
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.RepositoryDependencies();
        services.AddAuthConfiguration(configuration);
        services.AddCorsConfig();
        services.Configure<ApiBehaviorOptions>(o => o.SuppressModelStateInvalidFilter = true);
    }

    public static void ServicesDependencies(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services
            .AddSingleton(_ => builder.Configuration)
            .AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        
        services
            .AddScoped<INotificator, Notificator>()
            .AddScoped<IPasswordHasher<User>, Argon2PasswordHasher<User>>();

        services
            .AddScoped<IUserService, UserService>();
    }
}