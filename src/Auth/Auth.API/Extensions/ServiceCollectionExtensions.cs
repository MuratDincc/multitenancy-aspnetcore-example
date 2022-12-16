using Auth.API.Data.Context;
using Auth.API.Services;
using Microsoft.EntityFrameworkCore;

namespace Auth.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddManagementDbContext(this IServiceCollection services)
    {
        services.AddDbContext<DbContext, ManagementDbContext>(m => m.UseSqlServer(e => e.MigrationsAssembly(typeof(ManagementDbContext).Assembly.FullName)));

        return services;
    }

    public static IServiceCollection RegisterManagementServices(this IServiceCollection services)
    {
        services.AddTransient<ICompanyService, CompanyService>();
        services.AddTransient<IUserService, UserService>();

        return services;
    }
}