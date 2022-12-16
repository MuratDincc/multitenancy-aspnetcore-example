using Shared.Domain.Entities;

namespace Auth.API.Data.Entities;

public class Pool : BaseEntity
{
    public string Name { get; set; }
    public string Host { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public int MaxDatabaseCount { get; set; }

    public List<Company> Companies { get; set; }
}