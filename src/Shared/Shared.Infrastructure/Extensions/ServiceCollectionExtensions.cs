using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Shared.Domain.Models;
using Shared.Infrastructure.Common;
using Shared.Infrastructure.Repository;
using Shared.Infrastructure.Service;
using System.Text;

namespace Shared.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddJWTAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtTokenConfig = services.ConfigureSettings<JwtTokenConfig>(configuration.GetSection("JwtTokenConfig"));

        services.AddAuthentication(x =>
                {
                    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, x =>
                {
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = jwtTokenConfig.ValidateIssuer,
                        ValidIssuer = jwtTokenConfig.ValidIssuer,
                        ValidateAudience = jwtTokenConfig.ValidateAudience,
                        ValidAudience = jwtTokenConfig.ValidAudience,
                        ValidateLifetime = jwtTokenConfig.ValidateLifetime,
                        ValidateIssuerSigningKey = jwtTokenConfig.ValidateIssuerSigningKey,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtTokenConfig.SecretKey)),
                        ClockSkew = TimeSpan.Zero
                    };
                });

        return services;
    }

    public static IServiceCollection RegisterSharedServices(this IServiceCollection services)
    {
        services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IWorkContext, WorkContext>();

        return services;
    }

    public static TConfig ConfigureSettings<TConfig>(this IServiceCollection services, IConfiguration configuration) where TConfig : class, new()
    {
        if (services == null) throw new ArgumentNullException(nameof(services));
        if (configuration == null) throw new ArgumentNullException(nameof(configuration));

        var config = new TConfig();
        configuration.Bind(config);
        services.AddSingleton(config);

        return config;
    }
}