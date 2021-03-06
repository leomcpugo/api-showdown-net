﻿using Amaris.ApiShowdown.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amaris.ApiShowdown.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
    }
}
