using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace LCIE
{
    class Program
    {
        static void Main(string[] args)
        {
            //FindIEProcess();
            SHDocVw.InternetExplorer IE = new SHDocVw.InternetExplorer();
            IE.Visible = true;

            IE.Width = 1200;
            IE.Height = 900;
            IE.Top = 20;
            IE.Left = 20;
            IE.ToolBar = 0;



            IE.Navigate("www.dell.com");
            //Console.WriteLine("Done");
            //Console.ReadKey();
        }

        static bool dumpIEWindows(Process[] processes)
        {
            bool abFoundHandle = false;
            if ((processes == null) || (processes.Length == 0))
            {
                Console.WriteLine("No IE Processes found");
            }
            else
            {
                foreach (Process nextProcess in processes)
                {
                    if (nextProcess.MainWindowHandle == IntPtr.Zero)
                    {
                        Console.Write("IE process with Window handle set to 0: " + nextProcess.Id.ToString());
                        Console.WriteLine(".  This could be the Broker, or the windows is not created yet");
                    }
                    else
                    {
                        abFoundHandle = true;
                        Console.WriteLine("IE process with handle: " + nextProcess.Id.ToString() + ".  Window Title: " + nextProcess.MainWindowTitle);
                    }
                }

            }
            return abFoundHandle;
        }
       
        private static void FindIEProcess()
        {
            //TODO:  Trap exceptions and take appropriate action if there is an exception

            Process[] arrayOfProcesses;
            Process aProcess;
            // See if there are any iexplore processes already
            arrayOfProcesses = System.Diagnostics.Process.GetProcessesByName("iexplore");

            //if (arrayOfProcesses.Length == 0)
            //{
            // create iexplore.exe process
            aProcess = Process.Start("iexplore.exe", " -left:0 -top:0  http://www.dell.com");

            aProcess.WaitForInputIdle();

            arrayOfProcesses = System.Diagnostics.Process.GetProcessesByName("iexplore");
            //}

            // TODO:  Add some safety valve here to abort the loop after a certain amount of time
            // or after a few iterations.

            while (dumpIEWindows(arrayOfProcesses) == false)
            {

                // no IE Windows with a handle so we need to wait for window creation.
                // another possibility is that the iexplore broker process has started and it
                // did not yet create the brokered process (see LCIE).

                // Take a nap...
                Thread.Sleep(500);
                arrayOfProcesses = System.Diagnostics.Process.GetProcessesByName("iexplore");
            }

            //Process targetProcess = arrayOfProcesses[0];
            //targetProcess.Handle
        }
    }
}
