using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Module39.Student
{
    public class Person : INotifyPropertyChanged
    {
        #region Properties

        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged();
            }
        }

        private string _faculties;
        public string Faculties
        {
            get { return _faculties; }
            set
            {
                _faculties = value;
                OnPropertyChanged();
            }
        }

        private DateTime? _Updated;
        public DateTime? LastUpdated
        {
            get { return _Updated; }
            set
            {
                _Updated = value;
                OnPropertyChanged();
            }
        }

        #endregion //Properties

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        #endregion //INotifyPropertyChanged

        public override string ToString()
        {
            return String.Format("{0,{2}}", Name,Faculties);
        }
    }
}
