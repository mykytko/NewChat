using Microsoft.AspNetCore.Mvc;
using NewChat.BLL;
using NewChat.DAL.Entities;

namespace NewChat.Controllers;

public class AuthController : Controller
{
    private IAuthService _authService;
    
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost, Route("/auth/login")]
    public IActionResult Login([FromBody] User user)
    {
        var identity = _authService.Authorize(user);
        if (identity == null)
        {
            return Unauthorized();
        }

        var response = new
        {
            access_token = identity,
            username = user.Login
        };

        return Json(response);
    }
}