using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using WelcomeExtended.Data;

namespace Welcome.Helpers
{
    internal static class UserHelper
    {
        public static string toString(this User user)
        {
            return "User: {\n  ID: " + user.Id +
                "\n  Names: " + user.Names +
                "\n  Email: " + user.Email +
                "\n  Faculty number: " + user.FacultyNumber +
                "\n  Expires: " + user.Expires +
                "\n  Role: " + user.Role +
                "\n}";
        }

        public static bool ValidateCredentials(this UserData userData, string? names, string? password)
        {
            if (string.IsNullOrWhiteSpace(names)) throw new Exception("The names field cannot be empty");
            if (string.IsNullOrWhiteSpace(password)) throw new Exception("The password field cannot be empty");

            return userData.ValidateUser(names, password);
        }

        public static User? GetUser(this UserData userData, string names, string password)
        {
            return userData.GetUser(names, password);
        }
    }
}
