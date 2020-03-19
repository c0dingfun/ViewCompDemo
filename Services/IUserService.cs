using System.Collections.Generic;
using System.Threading.Tasks;

namespace ViewCompDemo.Services
{
    public interface IUserService
    {
        Task<List<User>> GetUserAsync();
        Task<User> GetUserAsync(int id);
    }
}