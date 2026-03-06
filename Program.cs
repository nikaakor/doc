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
                Console.WriteLine("\nAvailable commands:");
                Console.WriteLine("1. generate csv - Generate a new CSV file");
                Console.WriteLine("2. import data  - Import data into the database (ORM)");
                Console.WriteLine("3. exit         - Exit the program");
                Console.Write("\nSelect an action (1-3): ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        GenerateDummyCsv(csvPath, 1000);
                        break;
                    case "2":
                        Console.WriteLine("--- Starting data import via ORM ---");
                        service.ImportUsersFromCsv(csvPath);
                        int total = repository.GetAll().Count();
                        Console.WriteLine($"Total users in database: {total}");
                        break;
                    case "3":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid command, please try again.");
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
                    sw.WriteLine($"User_{i},user{i}@test.com");
                }
            }
            Console.WriteLine($"[Success] Generated file: {path}");
        }
    }
}