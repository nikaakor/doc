using Microsoft.EntityFrameworkCore;
using Lab2ServerApp.Models;

namespace Lab2ServerApp.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=lab2_database.db");
        }
    }
}