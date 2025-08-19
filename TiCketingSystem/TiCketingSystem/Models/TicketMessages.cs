using System;
using System.ComponentModel.DataAnnotations;

namespace TiCketingSystem.Models
{
    public class TicketMessages
    {
        [Key]
        public int Id { get; set; }

        // ارتباط با تیکت
        public int TicketId { get; set; }
        public Tickets Ticket { get; set; } = null!;

        // ارتباط با کاربر
        public int UserId { get; set; }
        public Users User { get; set; } = null!;

        [Required]
        public string Message { get; set; }

        public DateTime SentAt { get; set; } = DateTime.Now;
    }
}
