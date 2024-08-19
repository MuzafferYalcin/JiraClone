using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public sealed class JiraDbContext : DbContext
    {
        public JiraDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasMany(c=> c.CreatedTickets)
            .WithOne(c => c.CreatedByUser)
            .HasForeignKey(c=>c.CreatedBy)
            .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<User>()
            .HasMany(c=> c.DeletedTickets)
            .WithOne(c => c.DeletedByUser)
            .HasForeignKey(c=>c.DeletedBy)
            .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<User>()
            .HasMany(c=> c.UpdatedTickets)
            .WithOne(c => c.UpdatedByUser)
            .HasForeignKey(c=>c.UpdatedBy)
            .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<User>()
            .HasMany(c=> c.ResponsibleTickets)
            .WithMany(c => c.ResponsibleUsers)
            .UsingEntity<Dictionary<string, object>>(
                    "UserTickets",
                    j => j.HasOne<Ticket>().WithMany().HasForeignKey("TicketId"),
                    j => j.HasOne<User>().WithMany().HasForeignKey("UserId")
                );
            

            base.OnModelCreating(modelBuilder);
        }
    }
}