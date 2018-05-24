using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Amaris.ApiShowdown.Services;
using Amaris.ApiShowdown.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Amaris.ApiShowdown.Controllers
{
    [Route("api/[controller]")]
    public class PolicyController : Controller
    {
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Policy> Get(string id)
        {
            var policiyList = await new PolicyService().GetPolicies();
            return policiyList.First(x => x.id == id);
        }

        // GET api/values/5
        [HttpGet("name/{name}")]
        public async Task<IEnumerable<Policy>> GetByUserName(string name)
        {
            var userList = await new UserService().GetUsers();
            var requestedUser = userList.FirstOrDefault(x => x.name.ToLower() == name.ToLower());
            if (requestedUser != null)
            {
                var policiyList = await new PolicyService().GetPolicies();
                return policiyList.Where(x => x.clientId == requestedUser.id);
            }

            return null;
        }
    }
}
