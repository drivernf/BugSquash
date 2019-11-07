using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class TicketModel
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public int TicketId { get; set; }
        public int Urgency { get; set; }
        public string Description { get; set; }
    }
}
