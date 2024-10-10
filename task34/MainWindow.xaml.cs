using System.Windows;
using System.Windows.Media.Animation;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        private bool isLightOn = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (!isLightOn)
            {
                // 开启指示灯，开始闪烁
                isLightOn = true;
                Storyboard mystoryboard = ((Storyboard)FindResource("sb"));
              mystoryboard.Begin(light, true);
                System.Threading.Thread.Sleep(1000);


                isLightOn = true;
            }
            else if(isLightOn == true)
            {
                // 关闭指示灯，停止闪烁
                isLightOn = false;
                Storyboard mystoryboard = ((Storyboard)FindResource("sb"));
                mystoryboard.Stop(light);
                isLightOn = false;
            }

        }
    }
}