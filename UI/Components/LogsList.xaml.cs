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

namespace UI.Components
{
    /// <summary>
    /// Interaction logic for LogsList.xaml
    /// </summary>
    public partial class LogsList : UserControl
    {
        public LogsList()
        {
            InitializeComponent();

            using (var context = new DatabaseContext())
            {
                var records = context.Logs.ToList();
                logs.DataContext = records;
            }
        }

        private void Logs_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DatabaseLog log = (DatabaseLog) ((DataGrid) sender).SelectedItem;

            if (log != null)
            {
                MessageBox.Show(log.toString(), "Log Information");
            }
        }
    }
}
