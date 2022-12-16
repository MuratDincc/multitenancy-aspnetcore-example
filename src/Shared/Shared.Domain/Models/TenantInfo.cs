namespace Shared.Domain.Models;

public class TenantInfo
{
    public class TenantDatabase
    {
        public string DatabaseName { get; set; }
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class TenantUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }

    public class TenantCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ApiKey { get; set; }
        public string SecretKey { get; set; }
    }

    public TenantCompany Company { get; set; }
    public TenantDatabase Database { get; set; }
    public TenantUser User { get; set; }
}
