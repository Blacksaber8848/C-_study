using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;


namespace task36
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Student> Students { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            //Students = new ObservableCollection<Student>
            //{
            //    new Student { Id = 1, Name = "Alice", Faculties = "Computer Science" },
            //    new Student { Id = 2, Name = "Bob", Faculties = "Mathematics" },
            //    new Student { Id = 3, Name = "Charlie", Faculties = "Physics" }
            //};
            studentsListBox.ItemsSource = Students;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // 从 Settings 加载学生信息
            string serializedStudents = Properties.Settings.Default.Students;
            if (!string.IsNullOrEmpty(serializedStudents))
            {
                Students = JsonConvert.DeserializeObject<ObservableCollection<Student>>(serializedStudents);
                studentsListBox.ItemsSource = Students;
            }
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
                string serializedStudents = JsonConvert.SerializeObject(Students);

                // 保存到 Settings
                Properties.Settings.Default.Students = serializedStudents;
                Properties.Settings.Default.Save();
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