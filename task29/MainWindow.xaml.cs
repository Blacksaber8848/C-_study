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

        private void TextBox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            // 获取 TextBox 中的数值
            int number;
            if (int.TryParse(textBoxNumber.Text, out number))
            {
                // 根据鼠标滚轮的方向增加或减少数值
                number = e.Delta > 0 ? number + 1 : number - 1;

                // 更新 TextBox 的 Text 属性
                textBoxNumber.Text = number.ToString();

                // 更新 ListBox 的内容
                UpdateListBoxItem(number);
            }
            else
            {
                // 如果 TextBox 中的内容不是有效数字，则重置为 0
                textBoxNumber.Text = "0";
            }

            // 阻止进一步处理鼠标滚轮事件
            e.Handled = true;
        }

        private void UpdateListBoxItem(int number)
        {
            // 清除现有的 ListBoxItem
            listBoxNumbers.Items.Clear();
            // 添加新的 ListBoxItem
            listBoxNumbers.Items.Add(number);
        }
    }
}