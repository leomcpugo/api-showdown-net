using Amaris.ApiShowdown.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Amaris.ApiShowdown.Services
{
    public class PolicyService : IPolicyService
    {
        public async Task<IEnumerable<Policy>> GetPolicies()
        {
            HttpClient client = new HttpClient();

            var content = await client.GetStringAsync("http://www.mocky.io/v2/580891a4100000e8242b75c5");
            var response = JsonConvert.DeserializeObject<PolicyResponse>(content);
            return response.policies;
        }

        private class PolicyResponse
        {
            public IEnumerable<Policy> policies { get; set; }
        }
    }
}
