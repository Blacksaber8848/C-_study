using System;
using System.IO;
using System.Text;

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

            // 创建一个新的列表，用于存储更新后的内容
            List<byte> updatedBytes = new List<byte>();

            // 在开始处添加AABBCC
            updatedBytes.Add(0xAA);
            updatedBytes.Add(0xBB);
            updatedBytes.Add(0xCC);

            // 遍历字节数组，查找并删除0x31, 0x32, 0x33序列
            for (int i = 0; i < fileBytes.Length; i++)
            {
                // 检查当前字节及后两个字节是否构成0x31, 0x32, 0x33序列
                if (i <= fileBytes.Length - 3 && fileBytes[i] == 0x31 && fileBytes[i + 1] == 0x32 && fileBytes[i + 2] == 0x33)
                {
                    // 跳过序列
                    i += 2;
                }
                else
                {
                    // 如果当前字节不是序列的一部分，添加到列表中
                    updatedBytes.Add(fileBytes[i]);
                }
            }

            // 将更新后的内容写入到新文件

            //写入文件
            using (var streamWriter = new StreamWriter(destinationFilePath))
            {

                string fileContent = Encoding.UTF8.GetString(updatedBytes.ToArray());
                //写入文件
                streamWriter.Write(fileContent);
            }



            Console.WriteLine("Updated content has been written to the new file.");
        }
        catch (Exception ex)
        {
            // 如果发生错误，输出错误信息
            Console.WriteLine("An error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}