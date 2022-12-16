using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.Common;
using Tenant.API.Data.Entities;

namespace Tenant.API.Data.Context;

public class TenantDbContext : DbContext
{
    #region Fields

    private readonly IWorkContext _workContext; 

    #endregion

    #region Ctor

    public TenantDbContext(DbContextOptions options, IWorkContext workContext) : base(options)
    {
        this._workContext = workContext;
    }

    #endregion

    #region Tables

    public DbSet<Customer> Customer { get; set; }
    public DbSet<Product> Product { get; set; }

    #endregion

    #region Methods

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var tenant = _workContext.Tenant;

        if (tenant != null)
        {
            optionsBuilder.UseSqlServer($"Server={tenant.Database.Host}; Database={tenant.Database.DatabaseName}; User ID={tenant.Database.Username}; Password={tenant.Database.Password}");
        }
    } 

    #endregion
}