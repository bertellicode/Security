using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Security.Infra.CrossCutting.Identity.Interfaces;

namespace Security.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUser _user;

        public ValuesController(IUser user)
        {
            _user = user;
        }

        // GET api/values
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<string>> Get()
        {
            var claims = _user.GetClaimsIdentity();

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
