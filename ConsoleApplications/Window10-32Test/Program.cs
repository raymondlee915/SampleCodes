using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Window10_32Test
{
    class Program
    {
        static void Main(string[] args)
        {

            string cc = Dell.KickStart.Agent.Plugins.Registration.Common.Win32Api.GetGeoISOName();
            string lan = Dell.KickStart.Agent.Plugins.Registration.Common.Win32Api.GetLanguage();

            Console.WriteLine("country code is {0}.", cc);
            Console.WriteLine("Language is {0}.", lan);

            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}
