using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
    public class TicketModel
    {
        public int TicketId { get; set; }
        public int Status { get; set; }
        public string Urgency { get; set; }
        [Required(ErrorMessage = "You must enter a description")]
        [MaxLength(length: 2500, ErrorMessage = "Cannot excede 2500 chars")]
        [MinLength(length: 1, ErrorMessage = "You must enter a description")]
        public string Description { get; set; }
    }
}