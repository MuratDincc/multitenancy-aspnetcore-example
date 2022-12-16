using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Shared.Domain.Models;
using Shared.Infrastructure.Service;

namespace Shared.Infrastructure.Middleware;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IAuthService _authService;

    public JwtMiddleware(RequestDelegate next, IAuthService authService)
    {
        this._next = next;
        this._authService = authService;
    }

    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
        {
            try
            {
                bool result = _authService.ValidateCurrentToken(token);

                if (result == false)
                {
                    return;
                }

                var tenantInfo = _authService.GetClaim(token, "TenantInfo");

                if (string.IsNullOrWhiteSpace(tenantInfo))
                {
                    return;
                }

                context.Items["TenantInfo"] = JsonConvert.DeserializeObject<TenantInfo>(tenantInfo);
            }
            catch
            {
                
            }
        }

        await _next(context);
    }
}