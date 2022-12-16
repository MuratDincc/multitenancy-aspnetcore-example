using Shared.Domain.Entities;

namespace Auth.API.Data.Entities;

public class User : BaseEntity
{
    public string Email { get; set; }
    public string Password { get; set; }

    public virtual List<Company_User_Mapping> Company_User_Mappings { get; set; }
}