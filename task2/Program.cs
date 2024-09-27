using System;
using System.IO;

class Program
{
    static void Main()
    {
        // 指定源文件路径
        string sourceFilePath = "test1.txt";
        // 指定目标文件路径
        string destinationFilePath = "test2.txt";

        try
        {
            // 读取所有行
            string context = File.ReadAllText(sourceFilePath);

            // 写入到目标文件
            File.WriteAllText(destinationFilePath, context);

            Console.WriteLine("File contents copied successfully.");
        }
        catch (Exception ex)
        {
            // 如果发生错误，输出错误信息
            Console.WriteLine("An error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}