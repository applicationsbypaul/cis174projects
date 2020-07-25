using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text;

namespace cis174projects.Models
{
    internal class SeedTickets : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> entity)
        {
            entity.HasData(
                new Ticket { Id = 1, Name = "Seeding ticket with database",
                    Description = "Testing out seeding valuse", PointValue = "1", 
                    SprintNumber = "100", StatusId = "todo" }
                );
        }
    }
}