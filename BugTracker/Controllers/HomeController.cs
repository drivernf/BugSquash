using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BugTracker.Models;
using DataLibrary;
using static DataLibrary.BusinessLogic.TicketProcessor;
using static BugTracker.Components.TicketView;

namespace BugTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Index Page View
        public IActionResult Index()
        {
            return View();
        }

        // Returns Ticket View Component
        [Route("ticket-view")]
        public IActionResult TicketView()
        {
            return ViewComponent("TicketView");
        }

        // Add Ticket Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTicket(TicketModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateTicket(0, model.Urgency, model.Description);
                return RedirectToAction("Index");
            }

            return View();
        }

        // Error Page View
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}