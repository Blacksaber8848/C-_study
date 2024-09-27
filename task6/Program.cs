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
            // 读取文件的所有字节
            byte[] fileBytes = File.ReadAllBytes(sourceFilePath);

            // 打开文件流用于写入
            using (var streamWriter = new StreamWriter(destinationFilePath, false))
            {
                // 遍历字节数组，每10字节为一组
                for (int i = 0; i < fileBytes.Length; i += 10)
                {
                    // 将当前位置的10字节写入到目标文件
                    // 使用Substring确保即使不足10字节，也不会超出数组界限
                    byte[] bytesToWrite = new byte[Math.Min(10, fileBytes.Length - i)];
                    Array.Copy(fileBytes, i, bytesToWrite, 0, bytesToWrite.Length);
                    streamWriter.WriteLine(BitConverter.ToString(bytesToWrite));
                }
            }

            Console.WriteLine("Data has been written to the destination file.");
        }
        catch (Exception ex)
        {
            // 如果发生错误，输出错误信息
            Console.WriteLine("An error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}