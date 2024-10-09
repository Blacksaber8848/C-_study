using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            textBoxContent.IsEnabled = false;

            // Update the enabled state of the TextBox whenever any CheckBox is checked or unchecked
            checkBox1.Checked += CheckBoxChangedEventArgs;
            checkBox1.Unchecked += CheckBoxChangedEventArgs;
            checkBox2.Checked += CheckBoxChangedEventArgs;
            checkBox2.Unchecked += CheckBoxChangedEventArgs;
            checkBox3.Checked += CheckBoxChangedEventArgs;
            checkBox3.Unchecked += CheckBoxChangedEventArgs;
        }

        private void CheckBoxChangedEventArgs(object sender, RoutedEventArgs e)
        {
            UpdateTextBoxEnabledState();
        }

        private void UpdateTextBoxEnabledState()
        {
            // Enable TextBox only if all CheckBoxes are checked
            textBoxContent.IsEnabled = checkBox1.IsChecked == true && checkBox2.IsChecked == true && checkBox3.IsChecked == true;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // This method is called when the TextBox content is changed.
            // You can add any additional logic here if needed.
        }
    }
}