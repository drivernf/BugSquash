using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class TicketModel
    {
        public int TicketId { get; set; }
        public int Status { get; set; }
        public List<int> Urgencies { get; set; }
            = new List<int>
            {
                0, 1, 2, 3
            }; // used to populate the list of options
        public int Urgency { get; set; }
        [Required(ErrorMessage = "You must enter a description")]
        public string Description { get; set; }
    }
}