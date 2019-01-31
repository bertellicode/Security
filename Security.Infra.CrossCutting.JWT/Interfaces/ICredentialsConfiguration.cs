using Microsoft.IdentityModel.Tokens;

namespace Security.Infra.CrossCutting.JWT.Interfaces
{
    public interface ICredentialsConfiguration
    {
        SymmetricSecurityKey SymmetricKeySigningCredentials { get; }

        SymmetricSecurityKey SymmetricKeyEncryptingCredentials { get; }

        SigningCredentials SigningCredentials { get; }

        EncryptingCredentials EncryptingCredentials { get; }
    }
}
