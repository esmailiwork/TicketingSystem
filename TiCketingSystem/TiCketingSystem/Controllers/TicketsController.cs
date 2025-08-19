using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TiCketingSystem.Services;

namespace TiCketingSystem.Controllers
{
    public class TicketsController : Controller
    {
        public readonly ITicketService _ticketService;
        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
            
        }
        public async Task<IActionResult> Index()
        {
            var tickets= await _ticketService.GetAllTickets();
            return View(tickets);
        }
        public async Task<IActionResult> Details(int id)
        {
            var tickets= await _ticketService.GetTicketsById(id);
            if (tickets==null) return NotFound();
            return View(tickets);
        }
    }
}
