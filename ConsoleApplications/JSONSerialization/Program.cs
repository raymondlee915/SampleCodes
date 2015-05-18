using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSONSerializationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string output = @"{
    a: 1,
    b: 2
}";
            var p = JsonConvert.DeserializeObject<Pair>(output);

            Console.WriteLine(p.a);

        }
    }

    internal class Pair
    {
        public int a { get; set; }
        public int b { get; set; }
    }
}
