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


            // 遍历字节数组，步长为1来检查序列
            for (int i = 0; i <= fileBytes.Length - 3; i += 1)
            {
                // 检查当前的3个字节中是否包含0x31, 0x32, 0x33序列
                if (fileBytes[i] == 0x31 && fileBytes[i + 1] == 0x32 && fileBytes[i + 2] == 0x33)
                {
                    // 如果找到序列，输出到命令行新的一行
                    Console.WriteLine("0x31, 0x32, 0x33");
                    Console.WriteLine(i);
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