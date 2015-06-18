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
            string username = "Everyone";
            var rights = System.Security.AccessControl.FileSystemRights.FullControl;
            var folderPath = @"C:\ProgramData\Dell\Dell Product Registration";
            var allowOrDeny = System.Security.AccessControl.AccessControlType.Allow;

           bool result = false;
           InheritanceFlags inherits = InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit;
           var propagateToChildren = PropagationFlags.None;
           var addResetOrRemove = AccessControlModification.Add;

           DirectoryInfo folder = new DirectoryInfo(folderPath);
           DirectorySecurity security = folder.GetAccessControl(AccessControlSections.All);
           FileSystemAccessRule accRule;
           if ("Everyone".Equals(username, System.StringComparison.InvariantCultureIgnoreCase))
           {
               var si = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
               accRule = new FileSystemAccessRule(si, rights, inherits, propagateToChildren, allowOrDeny);
           }
           else
           {
               accRule = new FileSystemAccessRule(username, rights, inherits, propagateToChildren, allowOrDeny);
           }
           security.ModifyAccessRule(addResetOrRemove, accRule, out result);
           folder.SetAccessControl(security);
            Console.WriteLine("Done");
            Console.ReadKey();
        }

      
          [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        static extern System.UInt16 GetUserDefaultUILanguage();
    }
}
