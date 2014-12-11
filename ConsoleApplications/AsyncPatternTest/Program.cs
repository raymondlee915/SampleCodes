using AsyncPatternTest.TestService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncPatternTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

           // var carTask = Task.Factory.StartNew<int>(BookCar);
           // var hotelTask = Task.Factory.StartNew<int>(BookHotel);
           //// var planeTask = Task.Factory.StartNew<int>(BookPlane);

           // var planeTask = hotelTask.ContinueWith(preTask => { 
           //     Console.WriteLine("we done with hotel, now plane"); BookPlane();
           // });

           // Console.WriteLine(planeTask.AsyncState);
                
            IService1 service = new Service1Client();
            var test = service.GetDataAsync(45);          
            Console.WriteLine(test.Result);

            Console.WriteLine("Finished in {0} sec.", watch.ElapsedMilliseconds / 1000.0);
            Console.WriteLine("Done");
            Console.ReadKey();
        }

        private static int BookCar()
        {
            Console.WriteLine("Start booking Car");
            Thread.Sleep(3000);
            Console.WriteLine("end booking Car");
            return 3;
        }

        private static int BookHotel()
        {
            Console.WriteLine("Start booking Hotel");
            Thread.Sleep(5000);
            Console.WriteLine("end booking Hotel");
            return 330;
        }

        private static int BookPlane()
        {
            Console.WriteLine("Start booking Plane");
            Thread.Sleep(8000);
            Console.WriteLine("end booking Plane");
            return 3333;
        }
    }
}
