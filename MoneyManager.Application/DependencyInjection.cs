using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoneyManager.Application.Configurations;

namespace MoneyManager.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration,
        WebApplicationBuilder builder)
    {
        services.ResolveDependencies(builder);
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddAuthConfiguration(configuration);
        services.AddCorsConfig();
        services.Configure<ApiBehaviorOptions>(o => o.SuppressModelStateInvalidFilter = true);
    }
}