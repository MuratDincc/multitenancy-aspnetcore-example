using Microsoft.AspNetCore.Http;
using Shared.Domain.Models;

namespace Shared.Infrastructure.Common;

public class WorkContext : IWorkContext
{
    #region Fields

    private readonly IHttpContextAccessor _httpContextAccessor;

    #endregion

    #region Ctor

    public WorkContext(IHttpContextAccessor httpContextAccessor)
    {
        this._httpContextAccessor = httpContextAccessor;
    }

    #endregion

    #region Property

    public TenantInfo? Tenant
    {
        get
        {
            return _httpContextAccessor?.HttpContext?.Items["TenantInfo"] as TenantInfo;
        }
    } 

    #endregion
}