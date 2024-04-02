using DataLayer.Database;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.ViewModels
{
    internal class LogListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private ObservableCollection<DatabaseLog> _Logs;

        public ObservableCollection<DatabaseLog> Logs
        {
            get { return _Logs; }
            set { _Logs = value; PropChanged("Logs"); }
        }

        public LogListViewModel()
        {
            using (var context = new DatabaseContext())
            {
                Logs = new ObservableCollection<DatabaseLog>(context.Logs.ToList());
            }
        }

        public void PropChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
