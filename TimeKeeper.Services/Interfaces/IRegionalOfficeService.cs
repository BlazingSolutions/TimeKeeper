using System.Collections.Generic;
using System.Threading.Tasks;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Services
{
    public interface IRegionalOfficeService
    {
        Task<RegionalOffice> CreateAsync(RegionalOffice regionalOffice);
        Task<bool> DeleteByIdAsync(int id);
        Task<IEnumerable<RegionalOffice>> GetAllAsync();
        Task<RegionalOffice> GetByIdAsync(int id);
        Task<RegionalOffice> UpdateAsync(RegionalOffice regionalOffice);
    }
}