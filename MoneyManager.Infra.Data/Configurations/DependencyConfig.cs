using Microsoft.Extensions.DependencyInjection;
using MoneyManager.Domain.Contratcts.Repositories;
using MoneyManager.Infra.Data.Repositories;

namespace MoneyManager.Infra.Data.Configurations;

public static class DependencyConfig
{
    public static void ResolveDependencies(this IServiceCollection services)
    {
        services
            .AddScoped<IUserRepository, UserRepository>();
    }
}