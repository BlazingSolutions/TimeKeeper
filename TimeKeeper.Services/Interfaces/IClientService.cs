using System.Collections.Generic;
using System.Threading.Tasks;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Services
{
    public interface IClientService
    {
        Task<Client> CreateAsync(Client client);
        Task<bool> DeleteByIdAsync(int id);
        Task<IEnumerable<Client>> GetAllAsync();
        Task<Client> GetByIdAsync(int id);
        Task<Client> UpdateAsync(Client client);
    }
}