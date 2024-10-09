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
        }

        private void numberTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // 只允许输入数字
            e.Handled = !char.IsDigit(e.Text, e.Text.Length - 1);

            // 检查当前文本框的值是否在 1-100 范围内
            if (int.TryParse(numberTextBox.Text, out int value))
            {
                if (value < 1 || value > 100)
                {
                    numberTextBox.Text = Math.Max(1, Math.Min(100, value)).ToString();
                }
            }
            else
            {
                // 如果输入的不是数字，就删除它
                numberTextBox.Text = string.Empty;
            }
        }
    }
}