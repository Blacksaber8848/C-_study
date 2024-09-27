using System;
using System.IO;

class Program


{
    static void Main()
    {
        // 指定要读取的文件路径

        string filePath = "test.txt";
        try
        {
            // 读取文件内容
            string content = File.ReadAllText(filePath);

            // 输出到控制台
            Console.WriteLine(content);
        }
        catch (Exception ex)
        {
            // 如果发生错误，输出错误信息
            Console.WriteLine("An error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}