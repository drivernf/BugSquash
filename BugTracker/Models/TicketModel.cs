using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
    public class TicketModel
    {
        public int TicketId { get; set; }
        public int Status { get; set; }
        public string Urgency { get; set; }
        [MaxLength(length: 2500, ErrorMessage = "Cannot excede 2500 chars")]
        public string Description { get; set; }
    }
}