using System;
using System.IO;

class Program
{
    static void Main()
    {
        // 指定文件路径
        string filePath = "test1.txt";

        try
        {
            // 读取文件的所有字节
            byte[] fileBytes = File.ReadAllBytes(filePath);

            // 输出每个字节的十六进制表示到控制台
            for (int i = 0; i < fileBytes.Length; i++)
            {
                Console.WriteLine("Byte {0}: {1:X2}", i, fileBytes[i]);
            }
        }
        catch (Exception ex)
        {
            // 如果发生错误，输出错误信息
            Console.WriteLine("An error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}