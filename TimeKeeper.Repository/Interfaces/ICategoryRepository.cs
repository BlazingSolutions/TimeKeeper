using System.Collections.Generic;
using System.Threading.Tasks;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Repository
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
        Task<bool> DeleteByIdAsync(int id);
        Task<List<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task<Category> UpdateAsync(Category category);
    }
}