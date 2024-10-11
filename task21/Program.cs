using System;
using System.IO;

class Program
{
    static void Main()
    {
        string dxfFilePath = "all.dxf"; // 替换为实际的DXF文件路径

        try
        {
            using (StreamReader reader = new StreamReader(dxfFilePath))
            {
                string line;
                bool inEntitiesSection = false;

                while ((line = reader.ReadLine()) != null)
                {
                    // 检查是否是ENTITIES段的开始
                    if (line.Trim().ToUpper().StartsWith("ENTITIES"))
                    {
                        inEntitiesSection = true;
                    }
                    // 检查是否是下一个段的开始或文件结束
                    else if (inEntitiesSection && (line.Trim().StartsWith("ENDENTITIES") || line.Trim().StartsWith("SECTION")))
                    {
                        break; // 结束ENTITIES段的读取
                    }
                    // 如果当前在ENTITIES段内，输出该行
                    else if (inEntitiesSection)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while reading the DXF file:");
            Console.WriteLine(ex.Message);
        }
    }
}