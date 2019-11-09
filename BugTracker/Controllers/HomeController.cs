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
                CreateTicket(0, model.Urgency, model.Description);

            return RedirectToAction("Index");
        }

        // Details Ticket Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult TicketDetails(TicketModel model)
        {
            Debug.WriteLine($"Dets: {model.Description}");
            return PartialView("_TicketDetails", model);
        }

        // Edit Ticket Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTicket(TicketModel model)
        {
            if (ModelState.IsValid)
                ModifyTicket(model.TicketId, model.Urgency, model.Description);

            return RedirectToAction("Index");
        }

        // Error Page View
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}