using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using DataLayer.Model;

namespace DataLayer.Helpers
{
    public static class DatabaseUserHelper
    {
        public static string toString(this DatabaseUser user)
        {
            return "User: {\n  ID: " + user.Id +
                "\n  Names: " + user.Names +
                "\n  Email: " + user.Email +
                "\n  Faculty number: " + user.FacultyNumber +
                "\n  Expires: " + user.Expires +
                "\n  Role: " + user.Role +
                "\n}";
        }
    }
}
