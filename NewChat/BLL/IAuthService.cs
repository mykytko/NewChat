using System.IdentityModel.Tokens.Jwt;
using NewChat.DAL.Entities;

namespace NewChat.BLL;

public interface IAuthService
{ 
    JwtSecurityToken? Authorize(User user);
}