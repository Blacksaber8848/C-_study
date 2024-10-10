using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfApp
{
    public class NumberToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string strValue && int.TryParse(strValue, out int number))
            {
                number = Math.Max(1, Math.Min(100, number));
                // 计算红色和绿色的值
                byte red = (byte)((number / 100.0) * 255); // 红色分量从 0 增加到 255
                    byte green = (byte)(1 - (number / 100.0) * 255); // 绿色分量从 255 减少到 0
                    Color.FromRgb(red, green, 0);
                // 返回一个从绿色渐变到红色的Color
                return new SolidColorBrush(Color.FromRgb(red, green, 0)); // 蓝色分量始终为 0
              
            }
            return Brushes.Green; // 默认颜色（白色）
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // 当文本框内容改变时，确保背景颜色更新
            TextBox textBox = sender as TextBox;
            int number;
            if (int.TryParse(textBox.Text, out number))
            {
                // 更新背景颜色
                textBox.Background = (Brush)FindResource("NumberToColorConverter");
            }
        }
    }
}