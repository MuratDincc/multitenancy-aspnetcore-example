namespace Auth.API.Models;

public class TokenRequestModel
{
    public int CompanyId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}