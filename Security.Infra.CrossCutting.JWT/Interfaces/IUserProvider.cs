using System.Collections.Generic;
using System.Security.Claims;

namespace Security.Infra.CrossCutting.JWT.Interfaces
{
    public interface IUserProvider
    {

        string Name { get; }

        string UserName { get; }

        int? GetUserId();

        bool IsAuthenticated();

        IEnumerable<Claim> GetClaimsIdentity();

        string GetCurrentBearer();

    }
}
