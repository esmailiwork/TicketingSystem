using TiCketingSystem.Models;

namespace TiCketingSystem.Services
{
    public interface ITicketService
    {
      Task <List<Tickets>> GetAllTickets ();
      Task<Tickets> GetTicketsById (int Id);
      Task<Tickets>CreateTicket(Tickets ticket);
      Task UpdateTickets (Tickets ticket);
      Task DeleteTicket (int Id);

    }
}
