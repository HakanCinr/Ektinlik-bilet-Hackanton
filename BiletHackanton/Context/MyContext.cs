using BiletHackanton.Models.Orm;
using Microsoft.EntityFrameworkCore;

namespace BiletHackanton.Context
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database=BiletDb; Trusted_Connection=True");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public IEnumerable<object> Event { get; internal set; }
    }
}
