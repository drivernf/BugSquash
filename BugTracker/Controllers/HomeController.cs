using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BugTracker.Models;
using static DataLibrary.BusinessLogic.TicketProcessor;
using static DataLibrary.BusinessLogic.TableProcessor;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Collections.Generic;

namespace BugTracker.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // Index Page View
        public IActionResult Index()
        {
            return RedirectToAction("projects");
        }

        [Route("project/{projectName}", Name = "project/{projectName}")]
        public IActionResult Index(string projectName)
        {
            if (CheckTable(UserId(), projectName)[0] == 0)
                return RedirectToAction("projects");
            else
            {
                var model = new TicketModel { ProjectName = projectName };
                return View(model);
            }
        }

        // Returns Basket Container Component
        [Route("basket")]
        public IActionResult Basket(string projectName)
        {
            return ViewComponent("BasketContainer", new { userId = UserId(), projectName });
        }

        // Returns Basket Container Component
        [Route("projects", Name = "projects")]
        public IActionResult Projects()
        {
            return View("Projects_View");
        }

        // Add Ticket Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTicket(TicketModel model)
        {
            if (ModelState.IsValid)
                CreateTicket(UserId(), 0, model.Urgency, model.Description);

            return RedirectToAction("Index");
        }

        // Edit Ticket Post
        [Route("edit-ticket")]
        public void EditTicket(int ticketId, string urgency, string description)
        {
            ModifyTicket(UserId(), ticketId, urgency, description);
        }

        // Delete Ticket Post
        [Route("delete-ticket")]
        public void DeleteTicket(int ticketId)
        {
            RemoveTicket(UserId(), ticketId);
        }

        // Change Status of Ticket Post
        [Route("status-ticket")]
        public IActionResult StatusTicket(string projectName, int ticketId, int status)
        {
            StatusChange(UserId(), projectName, ticketId, status);
            return ViewComponent("BasketContainer", new { userId = UserId(), projectName });
        }

        // Add Project
        [Route("add-project")]
        public IActionResult AddProject(string projectName)
        {
            Debug.WriteLine($"Creating project: {projectName}");
            CreateTable(UserId(), projectName);
            return ViewComponent("BasketContainer", new { userId = UserId() });
        }

        // Get Project
        [Route("get-project")]
        public IActionResult GetProject(string projectName)
        {
            Debug.WriteLine($"Getting project: {projectName}");
            //GetTable(UserId(), projectName);
            return ViewComponent("BasketContainer", new { userId = UserId() });
        }

        // Error Page View
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public string UserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier).Replace("-", "");
        }
    }
}