using Microsoft.AspNetCore.Mvc;
using BugTracker.Models;

namespace BugTracker.Components
{
    public class Details : ViewComponent
    {
        public IViewComponentResult Invoke(TicketModel ticket)
        {
            return View("Details_View", ticket);
        }
    }
}