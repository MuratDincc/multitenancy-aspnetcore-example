using Shared.Domain.Models;

namespace Auth.API.Services;

public interface IUserService
{
    TenantInfo Login(int companyId, string email, string password); 
}