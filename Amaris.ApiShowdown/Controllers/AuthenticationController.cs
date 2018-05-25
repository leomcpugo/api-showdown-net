using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Amaris.ApiShowdown.Services;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Amaris.ApiShowdown.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        // POST api/values
        [AllowAnonymous]
        [HttpPost]
        public async Task<ContentResult> Post([FromBody]AuthenticationForm form)
        {
            var userList = await new UserService().GetUsers();

            var response = new ContentResult
            {
                Content = _authenticationService.SignToken(userList.FirstOrDefault(x => x.id == form.id)),
                StatusCode = 200
            };

            return await Task.FromResult(response);
        }

        public class AuthenticationForm
        {
            public string id { get; set; }
        }
    }
}
