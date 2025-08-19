
using System.ComponentModel.DataAnnotations;

namespace TiCketingSystem.Models
{
    public enum TicketStatus
    {
        Open = 0,
        InProgress = 1,
        Waiting = 2,
        Closed = 3
    }

    public class Tickets
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(300)]
        public string Title { get; set; }

        public string Description { get; set; }

        public TicketStatus Status { get; set; } = TicketStatus.Open;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        public int UserId { get; set; }
        public Users User { get; set; }

        // Navigation property
        public ICollection<TicketMessages> Messages { get; set; } = new List<TicketMessages>();
    }
}
