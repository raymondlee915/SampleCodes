using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegistryTest
{
    class Program
    {
        public static readonly string OobeComplete = "IMAGE_STATE_COMPLETE";

        static void Main(string[] args)
        {
            var value =Convert.ToString(ReadOOBE());

            while (!OobeComplete.Equals(value, StringComparison.InvariantCultureIgnoreCase))
            {

            }

            Console.WriteLine(value);

            Console.ReadLine();
        }

        private static object ReadOOBE()
        {
            string subKey = @"Software\Microsoft\Windows\CurrentVersion\Setup\State";
            RegistryKey rsg = null;

            if (Environment.Is64BitOperatingSystem)
            {
                rsg = Registry.LocalMachine.OpenSubKey(subKey, false);
            }
            else
            {
                rsg = Registry.LocalMachine.OpenSubKey(subKey, false);
            }


            var value = rsg.GetValue("ImageState");
            return value;
        }
    }
}
