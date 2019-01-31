using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace Security.Infra.CrossCutting.JWT.Interfaces
{
    public interface ITokenConfiguration
    {
        SymmetricSecurityKey SymmetricKeySigningCredentials { get; }

        SymmetricSecurityKey SymmetricKeyEncryptingCredentials { get; }

        string Audience { get; set; }

        string Issuer { get; set; }

        int MinutesValid { get; set; }

        Task<string> GenerateToken(ClaimsIdentity identityClaims);
    }
}
