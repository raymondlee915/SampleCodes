using NormalTest.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
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

            //Settings.Default.Test = true;
            //Settings.Default.Save();

            //Console.WriteLine(Settings.Default.Test);

            //var lcFolder = Environment.ExpandEnvironmentVariables(@"%SystemDrive%\Program Files\Dell\Dell Help & Support");
            //Console.WriteLine("With LC: {0}, LCFolder = {1}", Directory.Exists(lcFolder), lcFolder);

            ////string input = "disposable.style.email.with+symbol@example.com";
            ////Regex regex = new Regex(@"^[^\]\\\\.[@:;<>%#,`\t |][^\]\\\\[@:;<>%#,`\t |]*@([^\]\\\\[@:;<>%#,`\t .|]+[.])+[^.0-9][^\]\\\\[@:;<>%#,`\t 0-9|]+$");
            ////Console.WriteLine(regex.IsMatch(input));

            //string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            //Console.WriteLine(path);
            var path = @"C:\Program Files\Dell\Dell Product Registration\Content\beautyshot\..\..\..\features\features-ar.json";
            Console.WriteLine(File.Exists(path));
            var validPath = Path.GetFullPath(@"C:\Program Files\Dell\Dell Product Registration\Content");
            var folder = Path.GetFullPath(path);
            Console.WriteLine(folder.StartsWith(validPath));
            Console.WriteLine(folder);
            Console.WriteLine("Done");
            Console.ReadKey();
        }

      
          [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        static extern System.UInt16 GetUserDefaultUILanguage();
    }
}
