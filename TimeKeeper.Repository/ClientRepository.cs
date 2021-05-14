using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly TimeKeeperContext _context;

        public ClientRepository(TimeKeeperContext context)
        {
            _context = context;
        }

        public async Task<Client> CreateAsync(Client client)
        {
            client.DateCreated = DateTime.Now;

            _context.Clients.Add(client);

            await _context.SaveChangesAsync();

            return client;
        }

        public async Task<List<Client>> GetAllAsync()
        {
            return await _context.Clients.Where(x => x.IsActive).ToListAsync();
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<Client> UpdateAsync(Client client)
        {
            client.DateModified = DateTime.Now;

            _context.Clients.Add(client);

            await _context.SaveChangesAsync();

            return client;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            Client client = await GetByIdAsync(id);

            if (client is null)
            {
                return false;
            }

            _context.Clients.Remove(client);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
