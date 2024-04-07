using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using UI.ViewModels;
using DataLayer.Helpers;
using System.Reflection;

namespace UI.Commands
{
    internal class AddUserLogCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        public StudentsListViewModel StudentsListViewModel { get; set; }

        public AddUserLogCommand()
        {
            StudentsListViewModel = new StudentsListViewModel();
        }

        public bool CanExecute(object? parameter)
        {
            DatabaseLog log = (DatabaseLog) parameter;

            return log != null && log.UserId != -1;
        }

        public void Execute(object? parameter)
        {
            DatabaseLog log = (DatabaseLog) parameter;
            DatabaseUser user = StudentsListViewModel.Records.Where(v => v.Id == log.UserId).FirstOrDefault()!;

            if (user != null)
            {
                MessageBox.Show(user.toString(), "User Information");
            }
            else
            {
                MessageBox.Show("The user no longer exists!", "User Information");
            }
        }
    }
}
