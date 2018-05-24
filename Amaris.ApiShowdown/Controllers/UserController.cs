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
    public class UserController : Controller
    {
        // GET: api/values
        [HttpGet]
        public async Task<User> Get(string id = null, string name = null)
        {
            var userList = await new UserService().GetUsers();
            if (id != null)
            {
                return userList.FirstOrDefault(x => x.id == id);
            }
            else if (name != null)
            {
                return userList.FirstOrDefault(x => x.name.ToLower() == name.ToLower());
            }

            return null;
        }
    }
}
