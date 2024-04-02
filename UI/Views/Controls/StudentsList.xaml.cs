using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using DataLayer.Database;
using UI.ViewModels;

namespace UI.Views.Controls
{
    /// <summary>
    /// Interaction logic for StudentsList.xaml
    /// </summary>
    public partial class StudentsList : UserControl
    {
        private readonly StudentsListViewModel _viewModel;

        public StudentsList()
        {
            InitializeComponent();
            _viewModel = new StudentsListViewModel();
            DataContext = _viewModel;
        }
    }
}
