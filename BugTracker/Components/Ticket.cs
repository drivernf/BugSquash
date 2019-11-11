using Microsoft.AspNetCore.Mvc;
using BugTracker.Models;

namespace BugTracker.Components
{
    public class Ticket : ViewComponent
    {
        public IViewComponentResult Invoke(TicketModel model)
        {
            return View("Ticket_View", model);
        }
    }
}