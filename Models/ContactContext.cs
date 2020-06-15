using Microsoft.EntityFrameworkCore;

namespace cis174projects.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options)
            : base(options)
        { }
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    ContactId = 1,
                    Name = "Paul Ford",
                    Number = "773-456-4441",
                    Address = "1234 TestingLane Dr. Iowa",
                    Note = "Coolest guy in the world."
                }
            );
        }
    }
}
