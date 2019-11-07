using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Models;
using System.Collections;
using static DataLibrary.BusinessLogic.TicketProcessor;
using System.Diagnostics;

namespace BugTracker.Components
{
    public class TicketView : ViewComponent
    {
        public IViewComponentResult Invoke(TicketBasket currBasket)
        {
            TicketBasket newBasket = GetBasket();
            return View(newBasket);
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
            //tickets = SortTickets(tickets);

            // Subdivide tickets into basket
            var basket = new TicketBasket();
            foreach (TicketModel t in tickets)
            {
                if (t.Status == 0) basket.active.Add(t);
                else if (t.Status == 1) basket.squashing.Add(t);
                else if (t.Status == 2) basket.squashed.Add(t);
            }

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

        /*
        // Sort Tickets by Urgency
        public List<TicketModel> SortTickets(List<TicketModel> tickets)
        {
            List<TicketModel> sortedTickets = new List<TicketModel>();
            foreach (TicketModel t in tickets) if (t.Urgency == 3) sortedTickets.Add(t);
            foreach (TicketModel t in tickets) if (t.Urgency == 2) sortedTickets.Add(t);
            foreach (TicketModel t in tickets) if (t.Urgency == 1) sortedTickets.Add(t);
            foreach (TicketModel t in tickets) if (t.Urgency == 0) sortedTickets.Add(t);
            return sortedTickets;
        }
        */
    }
}