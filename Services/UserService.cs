using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ViewCompDemo.Services
{
    public class UserService : IUserService
    {
        public async Task<List<User>> GetUserAsync()
        {
            using (var client = new HttpClient())
            {
                var endpoint = "https://jsonplaceholder.typicode.com/users";
                var json = await client.GetStringAsync(endpoint);
                return JsonConvert.DeserializeObject<List<User>>(json);
            }
        }

        public async Task<User> GetUserAsync(int id)
        {
            using (var client = new HttpClient())
            {
                var endpoint = $"https://jsonplaceholder.typicode.com/users/{id}";
                var json = await client.GetStringAsync(endpoint);
                return JsonConvert.DeserializeObject<User>(json);
            }
        }
    }
}