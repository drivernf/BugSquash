using System.Collections.Generic;

namespace BugTracker.Models
{
    public class TicketBasket
    {
        public TicketModel ticket = new TicketModel();
        public string projectName;
        public List<TicketModel> ticketList = new List<TicketModel>();
        public List<TicketModel> active = new List<TicketModel>();
        public List<TicketModel> squashing = new List<TicketModel>();
        public List<TicketModel> squashed = new List<TicketModel>();
    }
}