using JwtApiAuth.Core.Models;

namespace JwtApiAuth.Core.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}