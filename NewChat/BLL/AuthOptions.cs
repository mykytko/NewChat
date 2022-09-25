using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace NewChat.BLL;

public class AuthOptions : IAuthOptions
{
    private readonly IConfigurationSection _jwt;

    public string Issuer => _jwt["Issuer"];
    public string Audience => _jwt["Audience"];
    public SymmetricSecurityKey Key => new(Encoding.UTF8.GetBytes(_jwt["Key"]));
    public int Lifetime => int.Parse(_jwt["Lifetime"]);

    public AuthOptions(IConfiguration configuration)
    {
        _jwt = configuration.GetSection("Jwt");
    }
}