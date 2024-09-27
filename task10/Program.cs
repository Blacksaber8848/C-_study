using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        // 指定工作目录路径
        string workDirectoryPath = Directory.GetCurrentDirectory(); // 默认使用当前工作目录，可以修改为其他路径

        try
        {
            // 获取工作目录中的所有txt文件
            string[] txtFiles = Directory.GetFiles(workDirectoryPath, "*.txt");

            foreach (string filePath in txtFiles)
            {
                // 读取文件的所有字节
                byte[] fileBytes = File.ReadAllBytes(filePath);

                // 创建一个列表，用于存储更新后的内容
                List<byte> updatedBytes = new List<byte>();

                // 遍历字节数组，查找并删除0xAA, 0xBB, 0xCC序列
                for (int i = 0; i < fileBytes.Length - 2; i++)
                {
                    // 检查当前字节及后两个字节是否构成0xAA, 0xBB, 0xCC序列
                    if (fileBytes[i] == 0xAA && fileBytes[i + 1] == 0xBB && fileBytes[i + 2] == 0xCC)
                    {
                        // 跳过序列
                        i += 2; // 跳过序列中的下一个字节
                    }
                    else
                    {
                        // 如果不是序列，添加到列表中
                        updatedBytes.Add(fileBytes[i]);
                    }
                }

                // 创建一个数组，用于存储更新后的内容
                byte[] finalBytes = updatedBytes.ToArray();

                // 写入到目标文件
                File.WriteAllBytes(filePath, finalBytes);

                Console.WriteLine($"Updated file: {filePath}");
            }

            Console.WriteLine("All files have been processed.");
        }
        catch (Exception ex)
        {
            // 如果发生错误，输出错误信息
            Console.WriteLine("An error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}