using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Security.Infra.CrossCutting.JWT.Interfaces;

namespace Security.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUserProvider _userProvider;

        public ValuesController(IUserProvider userProvider)
        {
            _userProvider = userProvider;
        }

        // GET api/values
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<string>> Get()
        {
            var claims = _userProvider.GetClaimsIdentity();

            var claimsRole = claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToList();

            return claimsRole;
        }

        [HttpGet]
        [Authorize(Roles = "Unauthorized")]
        [Route("unauthorized")]
        public ActionResult<IEnumerable<string>> GetUnauthorized()
        {
            return new string[] { "value1", "value2" };
        }

    }
}
