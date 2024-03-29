using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfExample.Windows;

namespace WpfExample.Commands
{
    public class InfoCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            MessageBox.Show("Hello, world!");

            NamesWindow window = new NamesWindow();
            window.Show();
        }
    }
}
