using Microsoft.IdentityModel.Tokens;

namespace NewChat.BLL;

public interface IAuthOptions
{
    string Issuer { get; }
    string Audience { get; }
    SymmetricSecurityKey Key { get; }
    int Lifetime { get; }
}