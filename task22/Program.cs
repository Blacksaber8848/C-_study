using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string dxfFilePath = "all.dxf"; // 替换为你的DXF文件路径

        try
        {
            using (StreamReader reader = new StreamReader(dxfFilePath))
            {
                string line;
                List<string> lineEntities = new List<string>();

                // 读取文件的每一行
                while ((line = reader.ReadLine()) != null)
                {
                    // 检查是否是LINE实体的开始
                    if (line.Trim().ToUpper().StartsWith("LINE"))
                    {
                        // 读取LINE实体的所有代码组，直到遇到下一个实体或段结束
                        lineEntities.Clear();
                        do
                        {
                            lineEntities.Add(line);
                            line = reader.ReadLine();
                        }
                        while (line != null && !line.Trim().StartsWith("0") && !line.Trim().ToUpper().StartsWith("ENDSEC"));

                        // 输出LINE实体的内容
                        Console.WriteLine("Found LINE entity:");
                        foreach (var entityLine in lineEntities)
                        {
                            Console.WriteLine(entityLine);
                        }
                        Console.WriteLine(); // 打印空行以分隔不同的LINE实体
                    }
                }
            }

            Console.WriteLine("Finished processing the DXF file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while reading the DXF file:");
            Console.WriteLine(ex.Message);
        }
    }
}