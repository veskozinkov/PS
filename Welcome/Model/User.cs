using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;

namespace Welcome.Model
{
    public class User
    {
        private string _password;

        public int Id { get; set; }

        public string Names { get; set; }

        public string Email { get; set; }

        public string FacultyNumber { get; set; }

        public string Password
        {
            get { return Encryption.EncryptDecrypt(_password, 158); }
            set { _password = Encryption.EncryptDecrypt(value, 158); }
        }

        public DateTime Expires { get; set; }

        public UserRolesEnum Role { get; set; }
    }
}
