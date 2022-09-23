using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace NewChat.BLL;

public class AccountService : IAccountService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AccountService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<IEnumerable<IdentityError>> Register(string login, string password)
    {
        var user = new IdentityUser {UserName = login};
        var result = await _userManager.CreateAsync(user, password);
        return result.Errors;
    }

    public async Task<bool> Login(string login, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(
            login, password, false, false);
        return result.Succeeded;
    }

    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<IEnumerable<IdentityError>> ChangePassword(HttpContext context, string oldPassword, string newPassword)
    {
        var id = context.User.Identity?.Name;
        if (id == null)
        {
            return new List<IdentityError>();
        }
        
        var user = await _userManager.FindByIdAsync(id);
        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        if (token == null)
        {
            return new List<IdentityError>();
        }
        var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
        return result.Errors;
    }
}