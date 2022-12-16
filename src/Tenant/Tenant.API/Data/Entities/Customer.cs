using Shared.Domain.Entities;

namespace Tenant.API.Data.Entities;

public class Customer : BaseEntity
{
    public Customer()
    {
        this.Deleted = false;
        this.CreatedOnUtc = DateTime.UtcNow;
        this.UpdatedOnUtc = DateTime.UtcNow;
    }
    
    public Guid Code { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public bool Deleted { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime UpdatedOnUtc { get; set; }
}