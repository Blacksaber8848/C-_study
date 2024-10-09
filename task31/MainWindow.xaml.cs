using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Data;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Set up the bindings
            Binding tripleBinding = new Binding
            {
                Source = textBoxNumber,
                Path = new PropertyPath(TextBox.TextProperty),
                Converter = new TripleConverter(),
                Mode = BindingMode.OneWay
            };
            textBoxTriple.SetBinding(TextBox.TextProperty, tripleBinding);
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Only allow digits and negative sign
            e.Handled = !char.IsDigit(e.Text, e.Text.Length - 1) && e.Text != "-";
        }
    }

    public class TripleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string strValue && int.TryParse(strValue, out int number))
            {
                return number * 3;
            }
            return 0; // Default value if conversion fails
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}