using Microsoft.EntityFrameworkCore;

namespace datagridview.Tour.Database
{
    public class DataGridContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=gridviewtour;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<Contracts.Models.Tour> Tours { get; set; }
    }
}
