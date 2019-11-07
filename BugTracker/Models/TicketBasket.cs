using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class TicketBasket
    {
        public TicketModel ticket = new TicketModel();
        public List<TicketModel> ticketList = new List<TicketModel>();
        public List<TicketModel> active = new List<TicketModel>();
        public List<TicketModel> squashing = new List<TicketModel>();
        public List<TicketModel> squashed = new List<TicketModel>();
    }
}