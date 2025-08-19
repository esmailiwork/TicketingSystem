using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TiCketingSystem.Models;

namespace TiCketingSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<Users> Users {  get; set; }    
        public DbSet<Roles> Roles {  get; set; }
        public DbSet<TicketMessages> TicketMessages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TicketMessages>()
                .HasOne(tm => tm.Ticket)
                .WithMany(t => t.Messages)
                .HasForeignKey(tm => tm.TicketId)
                .OnDelete(DeleteBehavior.Cascade); // حذف پیام‌ها وقتی تیکت حذف شود

            modelBuilder.Entity<TicketMessages>()
                .HasOne(tm => tm.User)
                .WithMany(u => u.TicketMessages)
                .HasForeignKey(tm => tm.UserId)
                .OnDelete(DeleteBehavior.Restrict); // کاربر حذف نشود یا پیام‌ها باقی بمانند
        }


    }
}
