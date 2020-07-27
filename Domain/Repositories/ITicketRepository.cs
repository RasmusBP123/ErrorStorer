using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetAll();
        Task<Ticket> GetTicketById(Guid id);
        Task<IEnumerable<Ticket>> TicketsSortedByType(TicketType type);
        Task<IEnumerable<Ticket>> TicketsSortedByStatus(Status status);
        Task CreateTicket(Ticket ticket);
    }
}
