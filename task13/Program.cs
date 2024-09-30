using System;
using System.IO;
using System.Threading;

class Program
{
    static void Main()
    {
        // 指定源文件和目标文件路径
        string sourceFilePath = "test1.txt";
        string destinationFilePath = "test2.txt";

        try
        {
            // 打开源文件
            using (FileStream sourceStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
            {
                // 创建目标文件
                using (FileStream destinationStream = new FileStream(destinationFilePath, FileMode.Create, FileAccess.Write))
                {
                    // 设置缓冲区
                    byte[] buffer = new byte[103]; // 1 KB
                    int bytesRead;
                    int totalBytesRead = 0;

                    // 添加开始标记
                    destinationStream.Write([0xAA, 0xBB, 0xCC], 0, 3);

                    // 读取和写入循环
                    while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        // 写入数据前添加延迟以限制速度
                        double delay = 1000; // 0.1 KB/s * 1000 ms/s / 1024 bytes/KB = 10 ms
                        // 检查是否需要移除0x31, 0x32, 0x33序列
                        for (int i = 0; i < bytesRead - 2; i++)
                        {
                            if (buffer[i] == 0x31 && buffer[i + 1] == 0x32 && buffer[i + 2] == 0x33)
                            {
                                Array.Copy(buffer, i + 3, buffer, i, bytesRead - i - 3);
                                bytesRead -= 3;
                                i -= 3;
                            }
                        }

                        if (totalBytesRead > 3) // 跳过开始的3个字节
                        {
                            Thread.Sleep((int)delay);
                        }

                        // 写入数据
                        destinationStream.Write(buffer, 0, bytesRead);
                        totalBytesRead += bytesRead;


                        // 调整缓冲区以补偿移除的字节
                        if (bytesRead < buffer.Length)
                        {
                            Array.Copy(buffer, bytesRead, buffer, 0, buffer.Length - bytesRead);
                        }
                    }
                }
            }

            Console.WriteLine("File processing complete.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}