using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cis174projects.Models
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options)
            : base(options) { }

        public DbSet<Ticket> TicketsP { get; set; }
        public DbSet<Status> StatusesP { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ticket: set composit primary key
            modelBuilder.Entity<Ticket>()
                .HasKey(t => new { t.Id });

            //Ticket: set foreign keys
            modelBuilder.Entity<Ticket>().HasOne(t => t.Status)
                .WithMany(s => s.Tickets)
                .HasForeignKey(t => t.StatusId);

            // seed initial data
            modelBuilder.ApplyConfiguration(new SeedTickets());
            modelBuilder.ApplyConfiguration(new SeedStatuses());
        }
    }
}
