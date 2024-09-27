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

            // 定义一个字符串来存储每行的字节表示
            string line = "";

            // 遍历字节数组，每10字节为一组
            for (int i = 0; i < fileBytes.Length; i++)
            {
                // 将字节添加到当前行字符串
                line += $"{fileBytes[i]:X2} ";

                // 检查是否已经添加了10字节，或者是否到达了最后一个字节
                if ((i + 1) % 10 == 0 || i == fileBytes.Length - 1)
                {
                    // 输出当前行字符串到控制台，并清空字符串为下一行做准备
                    Console.WriteLine(line);
                    line = "";
                }
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