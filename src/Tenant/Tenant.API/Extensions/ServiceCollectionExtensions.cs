using Microsoft.EntityFrameworkCore;
using Tenant.API.Data.Context;
using Tenant.API.Services;

namespace Tenant.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTenantDbContext(this IServiceCollection services)
    {
        services.AddDbContext<DbContext, TenantDbContext>(m => m.UseSqlServer(e => e.MigrationsAssembly(typeof(TenantDbContext).Assembly.FullName)));

        return services;
    }

    public static IServiceCollection RegisterTenantServices(this IServiceCollection services)
    {
        services.AddTransient<ICustomerService, CustomerService>();
        services.AddTransient<IProductService, ProductService>();

        return services;
    }
}