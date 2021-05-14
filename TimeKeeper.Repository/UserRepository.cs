using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TimeKeeperContext _context;

        public UserRepository(TimeKeeperContext context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User user)
        {
            user.DateCreated = DateTime.Now;

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.Where(x => x.IsActive).ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> UpdateAsync(User user)
        {
            user.DateModified = DateTime.Now;

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            User user = await GetByIdAsync(id);

            if (user is null)
            {
                return false;
            }

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
