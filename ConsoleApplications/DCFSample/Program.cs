using Dell.Client.Framework.Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCFSample
{
    class Program
    {
        static void Main(string[] args)
        {
            string productName = "ProductTest";
            string applicationName = "ApplicationName";
            string logNamePrefix = "TestProduct";
            string productVersion = "2.3";
          
            Console.WriteLine("LearningCenter Agent Console starting.");
            Console.WriteLine("ProductName     = \"{0}\"", productName);
            Console.WriteLine("ApplicationName = \"{0}\"", applicationName);
            Console.WriteLine("ProductVersion  = \"{0}\"", productVersion);
            Console.WriteLine("LogNamePrefix   = \"{0}\"", logNamePrefix);

            using (Agent agent = new Agent(applicationName, productName, productVersion, logNamePrefix))
            {
                bool flag = false;
                while (!flag)
                {
                    if (agent.IsThreadAlive)
                    {
                        Console.WriteLine("same agent has already running");
                    }
                    else
                    {
                        agent.StartThread();
                    }

                    Console.WriteLine("Press Enter to exit");
                    Console.WriteLine("----------------------------------------");
                    Console.ReadLine();
                    flag = true;
                }

                agent.StopThread();
            }
        }
    }
}
