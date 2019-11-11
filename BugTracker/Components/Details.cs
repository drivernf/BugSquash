using Microsoft.AspNetCore.Mvc;
using BugTracker.Models;
using System.Collections.Generic;
using static DataLibrary.BusinessLogic.TicketProcessor;
using System.Linq;

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