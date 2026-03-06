using Lab2ServerApp.Interfaces;
using Lab2ServerApp.Models;
using System;
using System.IO;
using System.Linq;

namespace Lab2ServerApp.BusinessLogic
{
    public class UserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public void ImportUsersFromCsv(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не знайдено!");
                return;
            }

            var existingEmails = _repository.GetAll().Select(u => u.Email).ToHashSet();
            var lines = File.ReadAllLines(filePath);
            int count = 0;

            foreach (var line in lines)
            {
                var data = line.Split(',');
                if (data.Length >= 2)
                {
                    string email = data[1].Trim();
                    if (!existingEmails.Contains(email))
                    {
                        _repository.Add(new User { Name = data[0].Trim(), Email = email });
                        existingEmails.Add(email);
                        count++;
                    }
                }
            }

            _repository.SaveChanges();
            Console.WriteLine($"Успішно імпортовано {count} нових записів.");
        }
    }
}