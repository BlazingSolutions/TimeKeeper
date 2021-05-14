using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Repository
{
    public class RegionalOfficeRepository : IRegionalOfficeRepository
    {
        private readonly TimeKeeperContext _context;

        public RegionalOfficeRepository(TimeKeeperContext context)
        {
            _context = context;
        }

        public async Task<RegionalOffice> CreateAsync(RegionalOffice regionalOffice)
        {
            regionalOffice.DateCreated = DateTime.Now;

            _context.RegionalOffices.Add(regionalOffice);

            await _context.SaveChangesAsync();

            return regionalOffice;
        }

        public async Task<List<RegionalOffice>> GetAllAsync()
        {
            return await _context.RegionalOffices.Where(x => x.IsActive).ToListAsync();
        }

        public async Task<RegionalOffice> GetByIdAsync(int id)
        {
            return await _context.RegionalOffices.FindAsync(id);
        }

        public async Task<RegionalOffice> UpdateAsync(RegionalOffice regionalOffice)
        {
            regionalOffice.DateModified = DateTime.Now;

            _context.RegionalOffices.Add(regionalOffice);

            await _context.SaveChangesAsync();

            return regionalOffice;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            RegionalOffice regionalOffice = await GetByIdAsync(id);

            if (regionalOffice is null)
            {
                return false;
            }

            _context.RegionalOffices.Remove(regionalOffice);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
