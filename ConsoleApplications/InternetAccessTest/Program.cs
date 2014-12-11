using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetAccessTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int errorDes = 0;
            Console.WriteLine(Win32Helper.InternetGetConnectedState(out errorDes, 0));

            Console.ReadKey();
        }
    }
}
