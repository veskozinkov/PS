using DataLayer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataLayer.Model;
using DataLayer.Helpers;
using UI.ViewModels;

namespace UI.Views.Controls
{
    /// <summary>
    /// Interaction logic for LogsList.xaml
    /// </summary>
    public partial class LogsList : UserControl
    {
        private readonly LogListViewModel _logListViewModel;
        private StudentsListViewModel _studentsListViewModel;

        public StudentsListViewModel StudentsListViewModel
        {
            get { return _studentsListViewModel; }
            set { _studentsListViewModel = value; }
        }

        public LogsList()
        {
            InitializeComponent();
            _logListViewModel = new LogListViewModel();
            DataContext = _logListViewModel;
        }

        private void Logs_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DatabaseLog log = (DatabaseLog) ((DataGrid) sender).SelectedItem;

            if (log != null && log.UserId != -1)
            {
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
}
