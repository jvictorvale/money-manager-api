using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MoneyManager.Application.Contracts;
using MoneyManager.Application.Notifications;
using MoneyManager.Application.Services;
using MoneyManager.Domain.Models;
using ScottBrady91.AspNetCore.Identity;

namespace MoneyManager.Application.Configurations;

public static class DependencyConfig
{
    public static void ResolveDependencies(this IServiceCollection services, WebApplicationBuilder builder)
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