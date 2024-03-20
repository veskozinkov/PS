using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using Welcome.Others;

namespace WelcomeExtended.Data
{
    internal class UserData
    {
        private List<User> _users;

        private int _nextId;

        public UserData()
        {
            _users = new List<User>();
            _nextId = 0;
        }

        public void AddUser(User user)
        {
            user.Id = _nextId++;
            _users.Add(user);
        }

        public User? GetUser(string names, string password)
        {
            if (ValidateUser(names, password))
            {
                return (from user in _users
                        where user.Names == names && user.Password == password
                        select user).FirstOrDefault();
            }

            return null;
        }

        public void DeleteUser(User user)
        {
            _users.Remove(user);
        }

        public void SetActive(string names, DateTime expires)
        {
            if (expires > DateTime.Now)
            {
                User? userToUpdate = (from user in _users
                             where user.Names == names
                             select user).FirstOrDefault();

                if (userToUpdate != null)
                {
                    userToUpdate.Expires = expires;
                }
            }
        }

        public void AssignUserRole(string names, UserRolesEnum role)
        {
            User? userToUpdate = (from user in _users
                                  where user.Names == names
                                  select user).FirstOrDefault();

            if (userToUpdate != null)
            {
                userToUpdate.Role = role;
            }
        }

        public bool ValidateUser(string names, string password)
        {
            foreach (var user in _users)
            {
                if (user.Names == names && user.Password == password)
                {
                    return true;
                }
            }

            return false;
        }

        public bool ValidateUserLambda(string names, string password)
        {
            return _users.Where(v => v.Names == names && v.Password == password).FirstOrDefault() != null ? true : false;
        }

        public bool ValidateUserLinq(string names, string password)
        {
            var ret = from user in _users
                      where user.Names == names && user.Password == password
                      select user.Id;

            return ret != null ? true : false;
        }
    }
}
