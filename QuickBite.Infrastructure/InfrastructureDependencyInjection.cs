using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using QuickBite.Application.Common.interfaces.Authentication;
using QuickBite.Application.Common.Interfaces.Persistence.Repositories;
using QuickBite.Infrastructure.Authentication;
using QuickBite.Infrastructure.Persistence;
using QuickBite.Infrastructure.Persistence.Repositories;

namespace QuickBite.Infrastructure;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {          
        services.AddSingleton<IUserRepository, UserRepository>();
        services.AddAuth(configuration);

        services.AddDbContext<QuickBiteDbContext>(options => {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseMySql(connectionString, 
            new MySqlServerVersion(new Version(8, 0, 0))
            // ServerVersion.AutoDetect(connectionString)
            );
        });
        
        return services;
    }

    public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
    {
        
        var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
    
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = jwtSettings?.Issuer,
                        ValidAudience = jwtSettings?.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                   }; 
                });

        return services;
    }

}