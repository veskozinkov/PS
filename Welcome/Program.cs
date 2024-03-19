using System.Data;
using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;

namespace Welcome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User
            {
                Names = "Ivan Dimitrov",
                Email = "idimitrov@tu-sofia.bg",
                FacultyNumber = "121221118",
                Password = "123456789_",
                Role = UserRolesEnum.STUDENT
            };

            UserViewModel userViewModel = new UserViewModel(user);
            UserView userView = new UserView(userViewModel);

            userView.DisplayBasic();
            Console.WriteLine();
            userView.DisplayFormattedColumns();
            Console.WriteLine();
            userView.DisplayFormattedColumnsWithBorderBox();
        }
    }
}
