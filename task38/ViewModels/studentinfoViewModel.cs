using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace task38.ViewModels
{
    public class studentinfoViewModel :BindableBase
    {
        private ObservableCollection<Student> _itemSource ;
        public ObservableCollection<Student> ItemSource
        {
            get { return _itemSource; }
            set { SetProperty(ref _itemSource, value); }
        }

        private string _selectedStudentNameTextBox_Text;
        public string selectedStudentNameTextBox_Text
        {
            get { return _selectedStudentNameTextBox_Text; }
            set { SetProperty(ref _selectedStudentNameTextBox_Text, value); }

        }      
        private string _selectedStudentIdTextBox_Text;
        public string selectedStudentIdTextBox_Text
        {
            get { return _selectedStudentIdTextBox_Text; }
            set { SetProperty(ref _selectedStudentIdTextBox_Text, value); }
        }

        private string _selectedStudentFacultiesTextBox_Text;

        public string selectedStudentFacultiesTextBox_Text
        {
            get { return _selectedStudentFacultiesTextBox_Text; }
            set { SetProperty(ref _selectedStudentFacultiesTextBox_Text, value); }
        }

        private Student _selectedItem;
        public Student SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value); }
        }


        public ObservableCollection<Student> Students { get; set; }
        public DelegateCommand UpdateButton_Click { get; }

        public DelegateCommand SelectionChanged { get; }

        public studentinfoViewModel()
        {
            UpdateButton_Click = new DelegateCommand(ExecuteCommand);

           SelectionChanged = new DelegateCommand(ListBox_SelectionChanged);
            Studentinfo_Loaded();

        }



        private void ExecuteCommand()
        {
            ExeUpdateButton_Click(this, new RoutedEventArgs());

        }         

        private void ExeUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedStudent = SelectedItem;
           // if (selectedStudent != null)
         //   {
                int newId;
                if (int.TryParse(selectedStudentIdTextBox_Text, out newId))
                {
                    selectedStudent.Id = newId;
                }
                selectedStudent.Name = selectedStudentNameTextBox_Text;
                selectedStudent.Faculties = selectedStudentFacultiesTextBox_Text;
                string serializedStudents = JsonConvert.SerializeObject(Students);

                // 保存到 Settings
                Properties.Settings.Default.Students = serializedStudents;
                Properties.Settings.Default.Save();
          //  }
        }
        private void Studentinfo_Loaded()
        {
            // 从 Settings 加载学生信息
            string serializedStudents = Properties.Settings.Default.Students;
            if (!string.IsNullOrEmpty(serializedStudents))
            {
                Students = JsonConvert.DeserializeObject<ObservableCollection<Student>>(serializedStudents);

            }
            else if (string.IsNullOrEmpty(serializedStudents))
            {
                Students = new ObservableCollection<Student>
                {
                    new Student { Id = 1, Name = "Alice", Faculties = "Computer Science" },
                    new Student { Id = 2, Name = "Bob", Faculties = "Mathematics" },
                    new Student { Id = 3, Name = "Charlie", Faculties = "Physics" }
                };
            }
                ItemSource = Students;

        }

        private void ListBox_SelectionChanged()
        {
            var selectedStudent = SelectedItem ;
            if (selectedStudent != null)
            {
                selectedStudentNameTextBox_Text = selectedStudent.Name;
                selectedStudentIdTextBox_Text = selectedStudent.Id.ToString();
                selectedStudentFacultiesTextBox_Text = selectedStudent.Faculties;
            }
        }

       
    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Faculties { get; set; }
    }

}
