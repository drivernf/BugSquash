using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BugTracker.Models;
using static DataLibrary.BusinessLogic.TicketProcessor;

namespace BugTracker.Components
{
    public class BasketContainer : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("BasketContainer_View", GetBasket());
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
            List<TicketModel> ticketsSorted = tickets.Where(x => x.Urgency == "vital").ToList();
            ticketsSorted.AddRange(tickets.Where(x => x.Urgency == "average"));
            ticketsSorted.AddRange(tickets.Where(x => x.Urgency == "minor"));
            ticketsSorted.AddRange(tickets.Where(x => x.Urgency == "none"));

            // Subdivide tickets into basket
            var basket = new TicketBasket
            {
                active = ticketsSorted.Where(x => x.Status == 0).ToList(),
                squashing = ticketsSorted.Where(x => x.Status == 1).ToList(),
                squashed = ticketsSorted.Where(x => x.Status == 2).ToList()
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
                Urgency = ConvertUrgency(t.Urgency),
                Description = t.Description,
            };
            return ticketModel;
        }

        public static string ConvertUrgency(int urgency)
        {
            if (urgency == 3) return "vital";
            else if (urgency == 2) return "average";
            else if (urgency == 1) return "minor";
            else return "none";
        }
    }
}