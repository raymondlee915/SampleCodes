using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteCommandTest
{
    class Program
    {
        static void Main(string[] args)
        {
           //// ShellExecute(0, "runas", LPCSTR("cmd.exe"), LPCSTR("/c net user administrator /active:yes"), "", SW_HIDE);
           // string output = ExeCommand(@"sc start ""Dell Product Registration""");
           // Console.WriteLine(output);

          //  StartService("Dell Product Registration", 10000);

            Process p = new Process();

            p.StartInfo.FileName = "sc.exe";
            p.StartInfo.CreateNoWindow = true;
           // p.StartInfo.UseShellExecute = false;
            p.StartInfo.Verb = "runas";
            p.StartInfo.Arguments = @"start ""Dell Product Registration""";

            p.Start();
            p.WaitForExit();
            p.Close();

            Console.WriteLine("done");
            Console.ReadKey();
        }

        public static string ExeCommand(string commandText)
        {
            Process p = new Process();
            p.StartInfo.FileName = "sc";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.Verb = "runas";
            p.StartInfo.Arguments = @"start ""Dell Product Registration""";

            ////The command that we want to run
            //string subCommand = @"sc start";

            ////The arguments to the command that we want to run
            //string subCommandArgs = @"""Dell Product Registration""";
            //string subCommandFinal = @"cmd /K \""" + subCommand.Replace(@"\", @"\\") + " " + subCommandArgs.Replace(@"\", @"\\") + @"\""";
            //p.StartInfo.Arguments = @"/env /user:Administrator ""cmd \""sc start \\\""Dell Product Registration\\\""\""""";
            string strOutput = null;
            try
            {
                p.Start();
                //p.StandardInput.WriteLine(commandText);
                p.StandardInput.WriteLine("exit");
                strOutput = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                p.Close();
            }
            catch (Exception e)
            {
                strOutput = e.Message;
            }
            return strOutput;
        }

        public static bool StartService(string serviceName, int timeoutMilliseconds)
        {
            ServiceController service = new ServiceController(serviceName);
            try
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);

                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, timeout);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            return true;
        }
    }
}
