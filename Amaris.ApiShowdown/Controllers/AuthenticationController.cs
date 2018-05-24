﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Amaris.ApiShowdown.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Amaris.ApiShowdown.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        // POST api/values
        [HttpPost]
        public async Task<ContentResult> Post([FromBody]AuthenticationForm form)
        {
            var userList = await new UserService().GetUsers();

            var response = new ContentResult
            {
                Content = new AuthenticationService().SignToken(userList.FirstOrDefault(x => x.id == form.id)),
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
