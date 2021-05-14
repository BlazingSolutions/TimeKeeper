using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TimeKeeperContext _context;

        public CategoryRepository(TimeKeeperContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            category.DateCreated = DateTime.Now;

            _context.Categories.Add(category);

            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.Where(x => x.IsActive).ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            category.DateModified = DateTime.Now;

            _context.Categories.Add(category);

            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            Category category = await GetByIdAsync(id);

            if (category is null)
            {
                return false;
            }

            _context.Categories.Remove(category);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
