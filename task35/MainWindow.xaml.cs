using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Student> Students { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Students = new ObservableCollection<Student>
            {
                new Student { Id = 1, Name = "Alice", Faculties = "Computer Science" },
                new Student { Id = 2, Name = "Bob", Faculties = "Mathematics" },
                new Student { Id = 3, Name = "Charlie", Faculties = "Physics" }
            };
            studentsListBox.ItemsSource = Students;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedStudent = studentsListBox.SelectedItem as Student;
            if (selectedStudent != null)
            {
                selectedStudentNameTextBox.Text = selectedStudent.Name;
                selectedStudentIdTextBox.Text = selectedStudent.Id.ToString();
                selectedStudentFacultiesTextBox.Text = selectedStudent.Faculties;
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedStudent = studentsListBox.SelectedItem as Student;
            if (selectedStudent != null)
            {
                int newId;
                if (int.TryParse(selectedStudentIdTextBox.Text, out newId))
                {
                    selectedStudent.Id = newId;
                }
                selectedStudent.Name = selectedStudentNameTextBox.Text;
                selectedStudent.Faculties = selectedStudentFacultiesTextBox.Text;
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