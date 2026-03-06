using Lab2ServerApp.Interfaces;
using Lab2ServerApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace Lab2ServerApp.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository()
        {
            _context = new AppDbContext();
            // Створює базу даних, якщо її ще немає
            _context.Database.EnsureCreated();
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }
    }
}