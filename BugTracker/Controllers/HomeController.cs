using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BugTracker.Models;
using static DataLibrary.BusinessLogic.TicketProcessor;

namespace BugTracker.Controllers
{
    public class HomeController : Controller
    {
        // Index Page View
        public IActionResult Index()
        {
            return View();
        }

        // Returns Basket Container Component
        [Route("basket")]
        public IActionResult Basket()
        {
            return ViewComponent("BasketContainer");
        }

        // Add Ticket Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTicket(TicketModel model)
        {
            if (ModelState.IsValid)
                CreateTicket(0, model.Urgency, model.Description);

            return RedirectToAction("Index");
        }

        // Edit Ticket Post
        [Route("edit-ticket")]
        public void EditTicket(int ticketId, string urgency, string description)
        {
            ModifyTicket(ticketId, urgency, description);
        }

        // Delete Ticket Post
        [Route("delete-ticket")]
        public void DeleteTicket(int ticketId)
        {
            RemoveTicket(ticketId);
        }

        // Change Status of Ticket Post
        [Route("status-ticket")]
        public void StatusTicket(int ticketId, int status)
        {
            StatusChange(ticketId, status);
        }

        // Error Page View
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}