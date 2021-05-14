using System.Collections.Generic;
using System.Threading.Tasks;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Repository
{
    public interface IRegionalOfficeRepository
    {
        Task<RegionalOffice> CreateAsync(RegionalOffice regionalOffice);
        Task<bool> DeleteByIdAsync(int id);
        Task<List<RegionalOffice>> GetAllAsync();
        Task<RegionalOffice> GetByIdAsync(int id);
        Task<RegionalOffice> UpdateAsync(RegionalOffice regionalOffice);
    }
}