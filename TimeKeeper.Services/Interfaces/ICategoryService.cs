using System.Collections.Generic;
using System.Threading.Tasks;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Services
{
    public interface ICategoryService
    {
        Task<Category> CreateAsync(Category category);
        Task<bool> DeleteByIdAsync(int id);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task<Category> UpdateAsync(Category category);
    }
}