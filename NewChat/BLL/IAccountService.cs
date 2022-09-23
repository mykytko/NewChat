using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace NewChat.BLL;

public interface IAccountService
{
    Task<IEnumerable<IdentityError>> Register(string login, string password);
    Task<bool> Login(string login, string password);
    Task Logout();
    Task<IEnumerable<IdentityError>> ChangePassword(HttpContext context, string oldPassword, string newPassword);
}