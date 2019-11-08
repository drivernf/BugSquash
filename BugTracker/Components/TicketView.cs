using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BugTracker.Models;
using static DataLibrary.BusinessLogic.TicketProcessor;

namespace BugTracker.Components
{
    public class TicketView : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(GetBasket());
        }

        // Create and Return Ticket Basket
        public TicketBasket GetBasket()
        {
            // Sql request from database
            var data = LoadTickets();

            // Create list of all tickets
            List<TicketModel> tickets = new List<TicketModel>();
            foreach (var row in data)
                tickets.Add(GetTicket(row));

            // Sort list of tickets by urgency
            tickets = tickets.OrderByDescending(x => x.Urgency).ThenBy(x => x.TicketId).ToList();

            // Subdivide tickets into basket
            var basket = new TicketBasket
            {
                active = tickets.Where(x => x.Status == 0).ToList(),
                squashing = tickets.Where(x => x.Status == 1).ToList(),
                squashed = tickets.Where(x => x.Status == 2).ToList()
            };

            // Return basket
            return basket;
        }

        // Create Client Ticket Model
        public TicketModel GetTicket(DataLibrary.Models.TicketModel t)
        {
            TicketModel ticketModel = new TicketModel
            {
                TicketId = t.Id,
                Status = t.Status,
                Urgency = t.Urgency,
                Description = t.Description,
            };
            return ticketModel;
        }
    }
}