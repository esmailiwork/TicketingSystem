using System.ComponentModel.DataAnnotations;

namespace TiCketingSystem.Models
{
    public class Roles
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        // Navigation property
        public ICollection<Users> Users { get; set; } = new List<Users>();
    }
}
