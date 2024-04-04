using DataLayer.Database;
using DataLayer.Model;
using Welcome.Others;
using Welcome.Model;
using Microsoft.Extensions.Logging;
using DataLayer.Helpers;

namespace DataLayer
{
    internal class Program
    {
        private static readonly ILogger databaseLogger = LoggerHelper.GetDatabaseLogger("MyDatabaseLogger");

        static void Main(string[] args)
        {
            using (var context = new DatabaseContext())
            {
                try
                {
                    int input = printMenu();
                    Console.WriteLine();

                    while (input != 4)
                    {
                        switch (input)
                        {
                            case 1:
                                List<DatabaseUser> users = GetAllUsers(context);

                                foreach (DatabaseUser user in users)
                                {
                                    Console.WriteLine(user.toString() + "\n");
                                }
                                Console.WriteLine();

                                break;

                            case 2:
                                AddNewUser(context);
                                break;

                            case 3:
                                DeleteUserByNames(context);
                                break;

                            case 100:
                                AddInitialUsers(context);
                                break;

                            default:
                                Console.WriteLine("Invalid input\n");
                                break;
                        }

                        input = printMenu();
                        Console.WriteLine();
                    }
                }
                catch (Exception e)
                {
                    databaseLogger.LogError(e.Message);
                }
            }
        }

        private static int printMenu()
        {
            Console.WriteLine("1. Get all users");
            Console.WriteLine("2. Add new user");
            Console.WriteLine("3. Delete user");
            Console.WriteLine("4. Exit\n");

            Console.Write("Input: ");
            return int.Parse(Console.ReadLine());
        }

        private static List<DatabaseUser> GetAllUsers(DatabaseContext context)
        {
            return context.Users.ToList();
        }

        private static void AddNewUser(DatabaseContext context)
        {
            Console.Write("Names: ");
            string? names = Console.ReadLine();

            Console.Write("Password: ");
            string? password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(names) || string.IsNullOrWhiteSpace(password)) throw new Exception("Invalid data when adding new user");

            context.Database.EnsureCreated();
            DatabaseUser newUser = new DatabaseUser()
            {
                Names = names,
                Password = password
            };
            context.Add<DatabaseUser>(newUser);
            context.SaveChanges();

            databaseLogger.LogInformation($"User with ID {newUser.Id} added successfully ID: {newUser.Id}");
            Console.WriteLine();
        }

        private static void DeleteUserByNames(DatabaseContext context)
        {
            Console.Write("Names: ");
            string? names = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(names)) throw new Exception("Invalid data when deleting user");

            context.Database.EnsureCreated();
            var userToDelete = context.Users.FirstOrDefault(u => u.Names == names);

            if (userToDelete != null)
            {
                context.Remove<DatabaseUser>(userToDelete);
                context.SaveChanges();

                databaseLogger.LogInformation($"User with ID {userToDelete.Id} deleted successfully");
                Console.WriteLine();
            }
            else
            {
                throw new Exception("User to delete was not found");
            }
        }

        private static void AddInitialUsers(DatabaseContext context)
        {
            context.Database.EnsureCreated();

            DatabaseUser adminUser = new DatabaseUser()
            {
                Id = 1,
                Names = "John Doe",
                Password = "1234",
                Role = UserRolesEnum.ADMIN,
                Expires = DateTime.Now.AddYears(10)
            };

            DatabaseUser inspectorUser = new DatabaseUser()
            {
                Id = 2,
                Names = "Georgi Ivanov",
                Password = "121212",
                Role = UserRolesEnum.INSPECTOR,
                Expires = DateTime.Now.AddYears(5)
            };

            DatabaseUser professorUser = new DatabaseUser()
            {
                Id = 3,
                Names = "Kalina Marinova",
                Password = "152637",
                Role = UserRolesEnum.PROFESSOR,
                Expires = DateTime.Now.AddYears(8)
            };

            DatabaseUser studentUser = new DatabaseUser()
            {
                Id = 4,
                Names = "Marina Georgieva",
                Password = "111222",
                Role = UserRolesEnum.STUDENT,
                Expires = DateTime.Now.AddYears(4)
            };

            context.Add<DatabaseUser>(adminUser);
            context.Add<DatabaseUser>(inspectorUser);
            context.Add<DatabaseUser>(professorUser);
            context.Add<DatabaseUser>(studentUser);

            context.SaveChanges();

            databaseLogger.LogInformation($"User with ID {adminUser.Id} added successfully ID: {adminUser.Id}");
            databaseLogger.LogInformation($"User with ID {inspectorUser.Id} added successfully ID: {inspectorUser.Id}");
            databaseLogger.LogInformation($"User with ID {professorUser.Id} added successfully ID: {professorUser.Id}");
            databaseLogger.LogInformation($"User with ID {studentUser.Id} added successfully ID: {studentUser.Id}");
        }
    }
}
