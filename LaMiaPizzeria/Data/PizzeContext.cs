using LaMiaPizzeria.Models;
using Microsoft.EntityFrameworkCore;

namespace LaMiaPizzeria.Data
{
    public class PizzeContext : DbContext
    {
        public DbSet<Pizze>? Pizze { get; set; }
        public DbSet<Categories>? Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=pizze_data;Integrated Security=True");
        }
    }
}
