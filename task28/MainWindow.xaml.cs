using System.Windows;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void valueSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // 更新 TextBox 的 Text 属性
            valueTextBox.Text = valueSlider.Value.ToString();
        }
    }
}