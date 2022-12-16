using Shared.Domain.Entities;

namespace Auth.API.Data.Entities;

public class Company_User_Mapping : BaseEntity
{
    public int CompanyId { get; set; }
    public int UserId { get; set; }

    public virtual Company Company { get; set; }
    public virtual User User { get; set; }
}