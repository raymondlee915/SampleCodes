using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JSONValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string folderPath = @"D:\Dell\KickStart\Dev\Source\Plugins\Features\Source\Plugin\Content\features";
            string[] filePaths = Directory.GetFiles(folderPath, "*.json", SearchOption.TopDirectoryOnly);
            foreach (string file in filePaths)
            {
                using (StreamReader fileReader = new StreamReader(file, true))
                {
                    try
                    {
                        Newtonsoft.Json.JsonConvert.DeserializeObject(fileReader.ReadToEnd());
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("file: {0}, error: {1}", Path.GetFileName(file), ex.Message);
                    }
                }
            }

            Console.WriteLine("done");
        }
    }
}
