using Microsoft.EntityFrameworkCore;
using Lab2ServerApp.Models;

namespace Lab2ServerApp.DataAccess
{
    public class AppDbContext : DbContext
    {
        // Додаємо = null!, щоб сказати компілятору: 
        // "Не хвилюйся, EF сам ініціалізує це поле під час роботи"
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Переконайтеся, що ви встановили Microsoft.EntityFrameworkCore.Sqlite
            optionsBuilder.UseSqlite("Data Source=lab2_database.db");
        }
    }
}