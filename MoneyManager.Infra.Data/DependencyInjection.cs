using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoneyManager.Domain.Contratcts.Repositories;
using MoneyManager.Infra.Data.Context;
using MoneyManager.Infra.Data.Repositories;

namespace MoneyManager.Infra.Data;

public static class DependencyInjection
{
    public static void AddInfraData(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        var serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect(connectionString));
        
        services.AddDbContext<ApplicationDbContext>(options => 
        { 
            options
                .UseMySql(connectionString, serverVersion)
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging(); 
        });
        
    }
    public static void RepositoryDependencies(this IServiceCollection services)
    {
        services
            .AddScoped<IUserRepository, UserRepository>();
    }
}