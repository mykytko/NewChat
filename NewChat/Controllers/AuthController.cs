using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewChat.BLL;
using NewChat.ViewModels;

namespace NewChat.Controllers;

public class AuthController : Controller
{
    private readonly IAccountService _accountService;

    public AuthController(IAccountService accountService)
    {
        _accountService = accountService;
    }
    
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var registerResult = await _accountService.Register(model);

        if (registerResult.Succeeded)
        {
            return Ok(await _accountService.Login(model));
        }

        foreach (var error in registerResult.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return BadRequest();
    }

    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        if (!await _accountService.IsValidUserCredentials(model))
        {
            return Unauthorized();
        }

        return Ok(await _accountService.Login(model));
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> ChangePassword([FromBody] PasswordChangeViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var login = HttpContext.User.Identity!.Name!;
        if (!await _accountService.IsValidUserCredentials(
                new LoginViewModel(login, model.OldPassword)))
        {
            return Unauthorized();
        }

        var changeResult = await _accountService.ChangePassword(HttpContext, model.NewPassword);

        if (changeResult.Succeeded)
        {
            return Ok(await _accountService.Login(new LoginViewModel(login, model.NewPassword)));
        }

        foreach (var error in changeResult.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return BadRequest();
    }
}