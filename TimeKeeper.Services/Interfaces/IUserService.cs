using System.Collections.Generic;
using System.Threading.Tasks;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Services
{
    public interface IUserService
    {
        Task<User> CreateAsync(User user);
        Task<bool> DeleteByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> UpdateAsync(User user);
    }
}