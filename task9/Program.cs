using System;
using System.IO;

class Program
{
    static void Main()
    {
        // 指定源文件路径
        string sourceFilePath = "test1.txt";
        // 指定目标文件前缀路径
        string destinationFilePrefixPath = "output";

        try
        {
            // 读取文件的所有字节
            byte[] fileBytes = File.ReadAllBytes(sourceFilePath);

            // 遍历字节数组，每10个字节进行一次处理
            for (int i = 0; i < fileBytes.Length; i += 10)
            {
                // 计算当前段的长度
                int segmentLength = Math.Min(10, fileBytes.Length - i);
                // 创建一个新的字节数组来存储当前段和前缀
                byte[] segmentBytes = new byte[segmentLength + 3];

                // 复制前缀到新数组
                segmentBytes[0] = 0xAA;
                segmentBytes[1] = 0xBB;
                segmentBytes[2] = 0xCC;

                // 复制当前段到新数组
                Array.Copy(fileBytes, i, segmentBytes, 3, segmentLength);

                // 创建一个新的文件名
                string newFileName = $"{destinationFilePrefixPath}_{i / 10}.txt";
                // 写入到目标文件
                File.WriteAllBytes(newFileName, segmentBytes);

                Console.WriteLine($"Segment saved to {newFileName}");
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