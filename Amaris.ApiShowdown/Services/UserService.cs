using Amaris.ApiShowdown.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Amaris.ApiShowdown.Services
{
    public class UserService : IUserService
    {
        public async Task<IEnumerable<User>> GetUsers()
        {
            HttpClient client = new HttpClient();

            var content = await client.GetStringAsync("http://www.mocky.io/v2/5808862710000087232b75ac");
            var response = JsonConvert.DeserializeObject<UserResponse>(content);
            return response.clients;
        }

        private class UserResponse
        {
            public IEnumerable<User> clients { get; set; }
        }
    }
}
