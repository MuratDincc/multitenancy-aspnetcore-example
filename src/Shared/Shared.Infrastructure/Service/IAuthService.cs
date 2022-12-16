using Shared.Domain.Models;

namespace Shared.Infrastructure.Service;

public interface IAuthService
{
    string GenerateToken(TenantInfo tenantInfo);
    bool ValidateCurrentToken(string token);
    string GetClaim(string token, string claimType);
}