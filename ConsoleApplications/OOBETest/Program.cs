using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOBETest
{
    class Program
    {
        static void Main(string[] args)
        {
            OobeChecker.OOBE_COMPLETED_CALLBACK callback = new OobeChecker.OOBE_COMPLETED_CALLBACK((p) =>
            {
                Console.WriteLine("OOBE is done, start loading plugins.");
                // TODO: OOBE is done, you can do anything you want here.
            });

            // Console.WriteLine(NativeMethods.OOBEComplete(out result));
            IntPtr handle = IntPtr.Zero;
            bool result = OobeChecker.RegisterWaitUntilOOBECompleted(callback, IntPtr.Zero, out handle);
            if (!result)
            {
                int lastError = OobeChecker.GetLastError();
                // if the lastError == 5023, means the OOBE is already done.
                if (lastError == 5023)
                {
                    callback(IntPtr.Zero);
                    result = true;
                }
                else
                {
                    Console.WriteLine("OOBE has not completed and KS failed to register itself to OS to be invoked by the time OOBE is completed.");
                    Console.WriteLine("KS will shutdown and will be restarted by OS.");

                    // The OOBE is not done yet, and also the registration is failed. 
                    // So we need to stop the service in this case.
                    Environment.Exit(1);
                }
            }
            else
            {
                Console.WriteLine("Waiting for OS to tell us when OOBE is done.");
            }

            Console.WriteLine("done");
            Console.ReadKey();
        }

        public static void OOBEDoneCallback(IntPtr CallbackContext)
        {
            Console.WriteLine("OOBE done");
        }
    }
}
