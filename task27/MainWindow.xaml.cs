using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        private bool isRed = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (isRed)
            {
                button.Background = new SolidColorBrush(Colors.Green);
                isRed = false;
            }
            else
            {
                button.Background = new SolidColorBrush(Colors.Red);
                isRed = true;
            }
        }
    }
}