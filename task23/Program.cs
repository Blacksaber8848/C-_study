using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string dxfFilePath = "all.dxf"; // 替换为你的 DXF 文件路径

        try
        {
            using (StreamReader reader = new StreamReader(dxfFilePath))
            {
                string line;
                List<LineSegment> lines = new List<LineSegment>();

                while ((line = reader.ReadLine()) != null)
                {
                    // 检查是否是 LINE 实体的开始
                    if (line.Trim().ToUpper().StartsWith("LINE"))
                    {
                        LineSegment lineSegment = ExtractLineSegment(reader);
                        if (lineSegment != null)
                        {
                            lines.Add(lineSegment);
                        }
                    }
                }

                // 判断相邻两条 LINE 是否尾首相接
                if (lines.Count >= 2)
                {
                    for (int i = 0; i < lines.Count - 1; i++)
                    {
                        LineSegment currentLine = lines[i];
                        LineSegment nextLine = lines[i + 1];

                        if (AreEndpointsConnected(currentLine.End, nextLine.Start))
                        {
                            Console.WriteLine($"LINE {i + 1} and LINE {i + 2} are connected end-to-start.");
                        }
                        else
                        {
                            Console.WriteLine($"LINE {i + 1} and LINE {i + 2} are NOT connected end-to-start.");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while reading the DXF file:");
            Console.WriteLine(ex.Message);
        }
    }

    private static bool AreEndpointsConnected(Point3D start, Point3D end)
    {
        return Math.Abs(start.X - end.X) < 1e-6 &&
               Math.Abs(start.Y - end.Y) < 1e-6 &&
               Math.Abs(start.Z - end.Z) < 1e-6;
    }

    private static LineSegment ExtractLineSegment(StreamReader reader)
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

        return new LineSegment(start, end);
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

public class LineSegment
{
    public Point3D Start { get; }
    public Point3D End { get; }

    public LineSegment(Point3D start, Point3D end)
    {
        Start = start;
        End = end;
    }
}