using Shared.Domain.Entities;

namespace Tenant.API.Data.Entities;

public class Product : BaseEntity
{
    public Product()
    {
        this.Deleted = false;
        this.CreatedOnUtc = DateTime.UtcNow;
        this.UpdatedOnUtc = DateTime.UtcNow;
    }

    public Guid Code { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool Deleted { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime UpdatedOnUtc { get; set; }
}