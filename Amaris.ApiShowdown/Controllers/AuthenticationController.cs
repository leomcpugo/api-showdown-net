using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Amaris.ApiShowdown.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        // POST api/values
        [HttpPost("login")]
        public void Post([FromBody]string id)
        {
        }
    }
}
