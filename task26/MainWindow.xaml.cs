using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace task26
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
      
            string dxfFilePath = "all.dxf"; // 替换为你的 DXF 文件路径

            try
            {

                using (StreamReader reader = new StreamReader(dxfFilePath))
                {
                    string point;
                    List<Point3D> points = new List<Point3D>();

                    while ((point = reader.ReadLine()) != null)
                    {
                        // 检查是否是 LINE 实体的开始
                        if (point.Trim().ToUpper().StartsWith("LINE"))
                        {
                            Point3D[] pointSegment = ExtractPoint(reader);
                            if (pointSegment != null)
                            {
                                points.Add(pointSegment[0]);
                                points.Add(pointSegment[1]);

                            }
                        }
                    }
                    MessageBox.Show("finshed", "good" ); 

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while reading the DXF file:");
                Console.WriteLine(ex.Message);
            }
        }

 


        private static Point3D[] ExtractPoint(StreamReader reader)
        {
            Point3D start = new Point3D(0, 0, 0);
            Point3D end = new Point3D(0, 0, 0);


            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Trim().StartsWith("10")) // DXF code for point X coordinate
                {
                    double x = double.Parse(reader.ReadLine());
                    start.X = x;
                }

                else if (line.Trim().StartsWith("20")) // DXF code for point Y coordinate
                {
                    double y = double.Parse(reader.ReadLine());
                    start.Y = y;
                }
                else if (line.Trim().StartsWith("30")) // DXF code for point Z coordinate
                {
                    double z = double.Parse(reader.ReadLine());
                    start.Z = z;
                }
                else if (line.Trim().StartsWith("11")) // DXF code for point Y coordinate
                {
                    double x = double.Parse(reader.ReadLine());
                    end.X = x;
                }
                else if (line.Trim().StartsWith("21")) // DXF code for point Z coordinate
                {
                    double y = double.Parse(reader.ReadLine());
                    end.Y = y;
                }
                else if (line.Trim().StartsWith("31")) // DXF code for point Z coordinate
                {
                    double z = double.Parse(reader.ReadLine());
                    end.Z = z;
                }

                else if (line.Trim().StartsWith("0")) // End of entity
                {
                    break;
                }
            }
            Point3D[] twopoints = [start, end];
            return   twopoints ;

        }
    }

    public struct Point3D
    {
        public double X, Y, Z;

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }


}
