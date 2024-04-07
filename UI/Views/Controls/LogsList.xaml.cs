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

        public LogsList()
        {
            InitializeComponent();
            _logListViewModel = new LogListViewModel();
            DataContext = _logListViewModel;
        }
    }
}
