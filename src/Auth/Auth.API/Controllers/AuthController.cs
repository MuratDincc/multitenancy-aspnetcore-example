using Auth.API.Models;
using Auth.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Infrastructure.Extensions;
using Shared.Infrastructure.Service;

namespace Auth.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AuthController : ControllerBase
{
    #region Fields

    private readonly IAuthService _authService;
    private readonly IUserService _userService;

    #endregion

    #region Ctor

    public AuthController(IAuthService authService, IUserService userService)
    {
        this._authService = authService;
        this._userService = userService;
    }

    #endregion

    #region Methods

    [AllowAnonymous]
    [HttpPost]
    public IActionResult Post([FromBody] TokenRequestModel model)
    {
        var loginResult = _userService.Login(model.CompanyId, model.Email, StringExtensions.ToSHA256String(model.Password));

        if (loginResult == null)
        {
            return Unauthorized();
        }

        var token = _authService.GenerateToken(loginResult);

        var responseJson = new
        {
            access_token = token,
            expires_in = (int)TimeSpan.FromMinutes(5000).TotalSeconds
        };

        return Ok(responseJson);
    }

    #endregion
}