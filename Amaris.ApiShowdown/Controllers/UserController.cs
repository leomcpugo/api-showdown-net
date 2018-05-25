using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Amaris.ApiShowdown.Services;
using Amaris.ApiShowdown.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Amaris.ApiShowdown.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/values
        [Authorize]
        [HttpGet]
        public async Task<User> Get(string id = null, string name = null)
        {
            var userList = await _userService.GetUsers();
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
