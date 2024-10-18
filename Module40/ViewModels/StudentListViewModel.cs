using Module40.Student;
using Module40.Views;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module40.ViewModels
{
    public class StudentListViewModel : BindableBase
    {
        private ObservableCollection<Person> _people;
        public ObservableCollection<Person> People
        {
            get { return _people; }
            set { SetProperty(ref _people, value); }
        }
 
        public DelegateCommand UpdateButton_Click { get; }

        public StudentListViewModel(IRegionManager regionManager)
        {
            LoadPeople();
            UpdateButton_Click = new DelegateCommand(ExeUpdateButton_Click);
          

        }

        private void LoadPeople()
        {
            string serializedStudents = Properties.Settings.Default.Students;
 
            if (!string.IsNullOrEmpty(serializedStudents))
            {
                 People = JsonConvert.DeserializeObject<ObservableCollection<Person>>(serializedStudents);

            }
            else if (string.IsNullOrEmpty(serializedStudents))
            {
                 var people = new ObservableCollection<Person>
                {
                    new Person { Id = 1, Name = "Alice", Faculties = "Computer Science" },
                    new Person { Id = 2, Name = "Bob", Faculties = "Mathematics" },
                    new Person { Id = 3, Name = "Charlie", Faculties = "Physics" }
                };
                People = people;
            }         
        }
        private void ExeUpdateButton_Click()
        {
           
            string serializedStudents = JsonConvert.SerializeObject(People);

            // 保存到 Settings
            Properties.Settings.Default.Students = serializedStudents;
            Properties.Settings.Default.Save();
            //  }
        }
    }
}
