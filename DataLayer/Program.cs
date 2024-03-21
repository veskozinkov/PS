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
                context.Database.EnsureCreated();
                context.Add<DatabaseUser>(new DatabaseUser()
                {
                    Names = "User",
                    Password = "password",
                    Expires = DateTime.Now,
                    Role = UserRolesEnum.STUDENT
                });
                context.SaveChanges();

                /*var users = context.Users.ToList();

                Console.Write("Names: ");
                string? names = Console.ReadLine();

                Console.Write("Password: ");
                string? password = Console.ReadLine();

                Console.WriteLine(users.Count);

                var ret = from user in users
                          where user.Names == names && user.Password == password
                          select user.Id;

                if (ret.Any())
                {
                    Console.WriteLine("Valid user");
                }
                else
                {
                    Console.WriteLine("Invalid data");
                }*/

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
            context.Add<DatabaseUser>(new DatabaseUser()
            {
                Names = names,
                Password = password
            });
            context.SaveChanges();

            databaseLogger.LogInformation("User added successfully");
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

                databaseLogger.LogInformation("User deleted successfully");
                Console.WriteLine();
            }
            else
            {
                throw new Exception("User to delete was not found");
            }
        }
    }
}
