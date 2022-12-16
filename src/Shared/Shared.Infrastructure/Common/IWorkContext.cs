using Shared.Domain.Models;

namespace Shared.Infrastructure.Common;

public interface IWorkContext
{
    public TenantInfo? Tenant { get; }
}