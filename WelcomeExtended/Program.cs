using Welcome.Helpers;
using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;
using WelcomeExtended.Data;
using WelcomeExtended.Others;

namespace WelcomeExtended
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                UserData userData = new UserData();

                User studentUser = new User() { Names = "Student", Password = "123", Role = UserRolesEnum.STUDENT };
                User student2User = new User() { Names = "Student2", Password = "123", Role = UserRolesEnum.STUDENT };
                User teacherUser = new User() { Names = "Teacher", Password = "1234", Role = UserRolesEnum.PROFESSOR };
                User adminUser = new User() { Names = "Admin", Password = "12345", Role = UserRolesEnum.ADMIN };

                userData.AddUser(studentUser);
                userData.AddUser(student2User);
                userData.AddUser(teacherUser);
                userData.AddUser(adminUser);

                Console.Write("Name: ");
                string? names = Console.ReadLine();

                Console.Write("Password: ");
                string? password = Console.ReadLine();

                if (userData.ValidateCredentials(names, password))
                {
                    User user = userData.GetUser(names!, password!)!;

                    var log = new ActionOnInfo(Delegates.FileInfoLog);
                    log($"({DateTime.Now}) Successful login for user:\n\n{user.toString()}");

                    Console.WriteLine(user.toString());
                }
                else
                {
                    var log = new ActionOnError(Delegates.FileErrorLog);
                    log($"({DateTime.Now}) Unsuccessful login for user with name: {names}");

                    throw new Exception("User not found");
                }
            }
            catch (Exception e)
            {
                var log = new ActionOnError(Delegates.Log);
                log(e.Message);
            }
            finally
            {
                Console.WriteLine("Executed in any case!");
            }
        }
    }
}
