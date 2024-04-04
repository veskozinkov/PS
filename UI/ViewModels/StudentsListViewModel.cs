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
    public class StudentsListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private ObservableCollection<DatabaseUser> _Records;

        public ObservableCollection<DatabaseUser> Records
        {
            get { return _Records; }
            set { _Records = value; PropChanged("Records"); }
        }

        public StudentsListViewModel()
        {
            using (var context = new DatabaseContext())
            {
                Records = new ObservableCollection<DatabaseUser>(context.Users.ToList());
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
