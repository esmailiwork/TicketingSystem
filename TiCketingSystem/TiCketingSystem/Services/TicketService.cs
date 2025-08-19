using Microsoft.EntityFrameworkCore;
using TiCketingSystem.Data;
using TiCketingSystem.Models;

namespace TiCketingSystem.Services
{
    public class TicketService : ITicketService
    {
        private readonly ApplicationDbContext _context;
        public TicketService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Tickets>> GetAllTickets()
        {
            return await _context.Tickets
                .Include(t=> t.User)
                .Include(t=> t.Messages)
                .ToListAsync();
        }
        public async Task<Tickets> GetTicketsById( int Id)
        {
            return await _context.Tickets
                .Include(t => t.User)
                .Include(t => t.Messages)
                .FirstOrDefaultAsync(t=> t.Id==Id);
            
        }
        public async Task<Tickets> CreateTicket(Tickets ticket)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChangesAsync();
            return ticket;
        }
        public async Task DeleteTicket(int Id) { 
            var ticket= await _context.Tickets.FindAsync(Id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateTickets(Tickets ticket)
        {
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();
        }

    }
}
