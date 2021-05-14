using System.Collections.Generic;
using System.Threading.Tasks;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Repository
{
    public interface IClientRepository
    {
        Task<Client> CreateAsync(Client client);
        Task<bool> DeleteByIdAsync(int id);
        Task<List<Client>> GetAllAsync();
        Task<Client> GetByIdAsync(int id);
        Task<Client> UpdateAsync(Client client);
    }
}