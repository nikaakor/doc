using Lab2ServerApp.Models;
using System.Collections.Generic;

namespace Lab2ServerApp.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        void SaveChanges();
        IEnumerable<User> GetAll();
    }
}