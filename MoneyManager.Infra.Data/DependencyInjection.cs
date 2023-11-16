using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoneyManager.Infra.Data.Configurations;
using MoneyManager.Infra.Data.Context;

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

        services.ResolveDependencies();
    }
}