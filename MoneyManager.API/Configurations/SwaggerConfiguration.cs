﻿using Microsoft.OpenApi.Models;

namespace MoneyManager.API.Configurations;

public static class SwaggerConfiguration
{
    public static void AddSwagger(this IServiceCollection services)
    {
        var contact = new OpenApiContact
        {
            Name = "João Victor Vale",
            Email = "joaovictorvale.dev@gmail.com",
            Url = new Uri("https://github.com/JVictorVale")
        };

        var license = new OpenApiLicense
        {
            Name = "Free License",
            Url = new Uri("https://github.com/JVictorVale")
        };

        services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = "v1",
                    Title = "Money Manager API",
                    Contact = contact,
                    License = license
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JSON Web Token based security",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
    }
}