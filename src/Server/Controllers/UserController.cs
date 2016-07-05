using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Server.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : Controller
    {
        // GET api/values
        [HttpGet]
        public IDictionary<string, string> Get()
        {
            var claims = User.Claims.ToDictionary(c => c.Type, c => c.Value);
            return claims;
        }
    }
}
