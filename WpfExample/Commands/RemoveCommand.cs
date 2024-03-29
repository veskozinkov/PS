using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfExample.Model;

namespace WpfExample.Commands
{
    public class RemoveCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            var namesList = parameter as NamesList;
            var oldName = namesList.SelectedName;
            namesList.Names.Remove(oldName);
        }
    }
}
