using System;
using Lab2ServerApp.DataAccess;
using Lab2ServerApp.BusinessLogic;
using Lab2ServerApp.Interfaces;
using System.Linq;

namespace Lab2ServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string csvPath = "users_data.csv";
            IUserRepository repository = new UserRepository();
            UserService service = new UserService(repository);

            while (true)
            {
                Console.WriteLine("\nДоступні команди:");
                Console.WriteLine("1. generate csv - Згенерувати новий CSV файл");
                Console.WriteLine("2. import data  - Імпортувати дані в базу (ORM)");
                Console.WriteLine("3. exit         - Вийти з програми");
                Console.Write("\nОберіть дію (1-3): ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        GenerateDummyCsv(csvPath, 1000);
                        break;
                    case "2":
                        Console.WriteLine("--- Старт імпорту в БД через ORM ---");
                        service.ImportUsersFromCsv(csvPath);
                        int total = repository.GetAll().Count();
                        Console.WriteLine($"Загальна кількість користувачів у базі: {total}");
                        break;
                    case "3":
                        Console.WriteLine("Вихід...");
                        return;
                    default:
                        Console.WriteLine("Невірна команда, спробуйте ще раз.");
                        break;
                }
            }
        }

        static void GenerateDummyCsv(string path, int count)
        {
            using (var sw = new System.IO.StreamWriter(path))
            {
                for (int i = 1; i <= count; i++)
                {
                    sw.WriteLine($"Користувач_{i},user{i}@test.com");
                }
            }
            Console.WriteLine($"[Успіх] Згенеровано файл: {path}");
        }
    }
}