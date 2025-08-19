using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiCketingSystem.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string FullName { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public int RoleId { get; set; }
        public Roles Role { get; set; }

        // Navigation properties
        public ICollection<Tickets> Tickets { get; set; } = new List<Tickets>();
        public ICollection<TicketMessages> TicketMessages { get; set; } = new List<TicketMessages>();
    }
}
