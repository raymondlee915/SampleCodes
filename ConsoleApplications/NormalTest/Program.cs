using NormalTest.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace NormalTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestLibrary.LibraryClass ins = new TestLibrary.LibraryClass();

            //Console.WriteLine("default key {0}", ins.GetDefaultKey());
            //Console.WriteLine(" key {0}", ins.Getkey());

            //ins.SetKey("custom key");

            //Console.WriteLine("default key {0}", ins.GetDefaultKey());
            //Console.WriteLine(" key {0}", ins.Getkey());

           // var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            //var value = GetUserDefaultUILanguage();
            //Console.WriteLine(value);

            //CultureInfo c = new CultureInfo(value);

            //Console.WriteLine(c.Name);

            Settings.Default.Test = true;
            Settings.Default.Save();

            Console.WriteLine(Settings.Default.Test);

            var lcFolder = Environment.ExpandEnvironmentVariables(@"%SystemDrive%\Program Files\Dell\Dell Help & Support");
            Console.WriteLine("With LC: {0}, LCFolder = {1}", Directory.Exists(lcFolder), lcFolder);

            Console.WriteLine("Done");
            Console.ReadKey();
        }

      
          [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        static extern System.UInt16 GetUserDefaultUILanguage();
    }
}
