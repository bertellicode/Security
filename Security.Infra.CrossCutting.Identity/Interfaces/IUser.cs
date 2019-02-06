using System.Collections.Generic;
using System.Security.Claims;

namespace Security.Infra.CrossCutting.Identity.Interfaces
{
    public interface IUser
    {

        string Name { get; }

        string UserName { get; }

        int? GetUserId();

        bool IsAuthenticated();

        IEnumerable<Claim> GetClaimsIdentity();

        string GetCurrentBearer();

    }
}
