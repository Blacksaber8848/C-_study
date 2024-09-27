using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        // 指定源文件路径
        string sourceFilePath = "test1.txt";

        try
        {
            // 读取文件的所有字节
            byte[] fileBytes = File.ReadAllBytes(sourceFilePath);

            bool sequenceFound = false;
            int sequenceStart = 0;

            // 遍历字节数组，查找序列
            for (int i = 0; i < fileBytes.Length - 2; i++)
            {
                // 检查当前字节及后两个字节是否构成0x31, 0x32, 0x33序列
                if (fileBytes[i] == 0x31 && fileBytes[i + 1] == 0x32 && fileBytes[i + 2] == 0x33)
                {
                    if (sequenceFound)
                    {
                        // 如果已找到序列，先保存之前的内容
                        SaveContent(fileBytes, sequenceStart, i - sequenceStart, sequenceStart);

                    }
                    sequenceStart = i;
                    sequenceFound = true;
                    i += 2; // 跳过当前序列
                }
            }

            // 保存最后一段内容
            if (sequenceFound)
            {
                SaveContent(fileBytes, sequenceStart, fileBytes.Length - sequenceStart, sequenceStart);
            }
        }
        catch (Exception ex)
        {
            // 如果发生错误，输出错误信息
            Console.WriteLine("An error occurred:");
            Console.WriteLine(ex.Message);
        }
    }

    static void SaveContent(byte[] fileBytes, int start, int length, int sequenceStart)
    {
        // 构建新文件名
        string newFileName = $"output_{sequenceStart}.txt";
        // 创建文件并写入内容
        using (var streamWriter = new StreamWriter(newFileName))
        {
            //创建新数组接收写入的字节
            byte[] middlePart = new byte[length];
            //将要接受的字节复制到新数组
            Array.Copy(fileBytes, start, middlePart, 0, middlePart.Length);
            //转化为字符
            string fileContent = Encoding.UTF8.GetString(middlePart);    
            //写入文件
            streamWriter.Write(fileContent);
        }
        Console.WriteLine($"Content written to {newFileName}");
    }
}