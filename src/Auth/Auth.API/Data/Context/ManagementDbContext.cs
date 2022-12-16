using Auth.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auth.API.Data.Context;

public class ManagementDbContext : DbContext
{
    #region Fields

    private readonly IConfiguration _configuration;

    #endregion

    #region Ctor

    public ManagementDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        this._configuration = configuration;
    }

    #endregion

    #region Tables

    public DbSet<Company> Company { get; set; }
    public DbSet<Company_User_Mapping> Company_User_Mapping { get; set; }
    public DbSet<Pool> Pool { get; set; }
    public DbSet<User> User { get; set; }

    #endregion

    #region Methods

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("MainDBConnection"));
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    } 

    #endregion
}