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
            // Sql request from database
            List<string> data = GetTables(UserId());

            // Create list of projects
            List<ProjectModel> projects = new List<ProjectModel>();
            foreach (string projectName in data)
                projects.Add(new ProjectModel { ProjectName = projectName.Substring(projectName.IndexOf("@") + 1) });

            return View("Projects_View", projects);
        }

        // Add Ticket Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTicket(TicketModel model)
        {
            Debug.WriteLine($"Add ticket for: {model.ProjectName}");
            if (ModelState.IsValid)
                CreateTicket(UserId(), model.ProjectName, 0, model.Urgency, model.Description);

            return Redirect($"/project/{model.ProjectName}");
        }

        // Edit Ticket Post
        [Route("edit-ticket")]
        public void EditTicket(string projectName, int ticketId, string urgency, string description)
        {
            ModifyTicket(UserId(), projectName, ticketId, urgency, description);
        }

        // Delete Ticket Post
        [Route("delete-ticket")]
        public void DeleteTicket(string projectName, int ticketId)
        {
            RemoveTicket(UserId(), projectName, ticketId);
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
        public void AddProject(string projectName)
        {
            Debug.WriteLine($"Creating project: {projectName}");
            CreateTable(UserId(), projectName);
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