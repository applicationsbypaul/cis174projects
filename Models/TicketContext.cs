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
            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = "todo", Name = "To Do" },
                new Status { StatusId = "inprogress", Name = "In Progress" },
                new Status { StatusId = "qa", Name = "Quality Assurance" },
                new Status { StatusId = "done", Name = "Done" }
                );
        }
    }
}
