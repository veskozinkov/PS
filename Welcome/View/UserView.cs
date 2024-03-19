using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.ViewModel;

namespace Welcome.View
{
    public class UserView
    {
        private UserViewModel _viewModel;

        public UserView(UserViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void DisplayBasic()
        {
            Console.WriteLine(
                "Welcome (Basic display)\n\nUser: " + _viewModel.Names +
                "\nEmail: " + _viewModel.Email +
                "\nFaculty number: " + _viewModel.FacultyNumber +
                "\nPassword: " + _viewModel.Password +
                "\nRole: " + _viewModel.Role
            );
        }

        public void DisplayFormattedColumns()
        {
            Console.WriteLine(
                $"Welcome (Formatted columns display)\n\n{"User:", -15} {_viewModel.Names}" +
                $"\n{"Email:", -15} {_viewModel.Email}" +
                $"\n{"Faculty number:", -15} {_viewModel.FacultyNumber}" +
                $"\n{"Role:", -15} {_viewModel.Role}"
            );
        }

        public void DisplayFormattedColumnsWithBorderBox()
        {
            string userString = $"{"User", -14} {"║ " + _viewModel.Names}";
            string emailString = $"{"Email", -14} {"║ " + _viewModel.Email}";
            string facultyNumberString = $"{"Faculty number", -14} {"║ " + _viewModel.FacultyNumber}";
            string roleString = $"{"Role", -14} {"║ " + _viewModel.Role}";

            int maxLineWidth = Math.Max(
                userString.Length,
                Math.Max(
                    emailString.Length,
                    Math.Max(facultyNumberString.Length, roleString.Length)
                )
            );

            Console.WriteLine(
                "Welcome (Formatted columns display with border box)\n\n" +
                "╔" + new string('═', maxLineWidth) + "╗" +
                "\n║" + userString + new string(' ', maxLineWidth - userString.Length) + "║" +
                "\n║" + emailString + new string(' ', maxLineWidth - emailString.Length) + "║" +
                "\n║" + facultyNumberString + new string(' ', maxLineWidth - facultyNumberString.Length) + "║" +
                "\n║" + roleString + new string(' ', maxLineWidth - roleString.Length) + "║" +
                "\n╚" + new string('═', maxLineWidth) + "╝"
            );
        }

        public void DisplayError()
        {
            throw new Exception("CUSTOM EXCEPTION");
        }
    }
}
