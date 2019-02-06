using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Security.Infra.CrossCutting.Identity.Interfaces;
using Security.Infra.CrossCutting.JWT.Interfaces;

namespace Security.Infra.CrossCutting.Identity.Models
{
    public class User : IUser
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly ITokenConfiguration _tokenConfiguration;

        public User(IHttpContextAccessor accessor,
                    ITokenConfiguration tokenConfiguration)
        {
            _accessor = accessor;
            _tokenConfiguration = tokenConfiguration;
        }

        public string UserName => _accessor.HttpContext.User.Identity.Name;

        public string Name
        {
            get
            {
                var clainsIdentity = _accessor.HttpContext.User.Identity as ClaimsIdentity;

                var claimValue = clainsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value;

                return claimValue;
            }
        }

        string IUser.UserName { get => _accessor.HttpContext.User.Identity.Name; }

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            var clainsIdentity = _accessor.HttpContext.User.Identity as ClaimsIdentity;

            return clainsIdentity.Claims;
        }

        public int? GetUserId()
        {
            var clainsIdentity = _accessor.HttpContext.User.Identity as ClaimsIdentity;

            var claimId = clainsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            int outValue;

            return int.TryParse(claimId, out outValue) ? (int?)outValue : null;
        }

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public string GetCurrentBearer()
        {
            return _tokenConfiguration.Bearer;
        }

    }
}
