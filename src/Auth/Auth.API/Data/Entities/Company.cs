using Shared.Domain.Entities;

namespace Auth.API.Data.Entities;

public class Company : BaseEntity
{
    public Company()
    {
        this.Deleted = false;
        this.CreatedOnUtc = DateTime.UtcNow;
        this.UpdatedOnUtc = DateTime.UtcNow;
    }

    public int PoolId { get; set; }
    public string Name { get; set; }
    public string DatabaseName { get; set; }
    public string ApiKey { get; set; }
    public string SecretKey { get; set; }
    public bool Deleted { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime UpdatedOnUtc { get; set; }

    public virtual Pool Pool { get; set; }
    public virtual List<Company_User_Mapping> Company_User_Mappings { get; set; }
}