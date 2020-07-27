using Domain;
using Domain.Repositories;
using Infrastructure.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly DbStorage _storage;

        public TicketRepository(DbStorage storage)
        {
            _storage = storage;
        }

        public async Task CreateTicket(Ticket ticket)
        {
            await _storage.AddAsync(ticket);
        }

        public async Task<IEnumerable<Ticket>> GetAll()
        {
            return await _storage.Tickets.ToListAsync();
        }

        public async Task<Ticket> GetTicketById(Guid id)
        {
            return await _storage.Tickets.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Ticket>> TicketsSortedByStatus(Status status)
        {
            return await _storage.Tickets.Where(t => t.Status == status).ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> TicketsSortedByType(TicketType type)
        {
            return await _storage.Tickets.Where(t => t.Type == type).ToListAsync();
        }
    }
}
