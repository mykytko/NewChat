using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NewChat.ViewModels;

namespace NewChat.BLL;

public interface IAccountService
{
    Task<bool> IsValidUserCredentials(LoginViewModel model);
    Task<IdentityResult> Register(LoginViewModel model);
    Task<LoginResult> Login(LoginViewModel model);
    Task<IdentityResult> ChangePassword(HttpContext context, string newPassword);
}