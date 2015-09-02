using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVCTest
{
    public class Utility
    {
        public static async Task<int> GetValue()
        {
            await Task.Delay(TimeSpan.FromSeconds(2));

            return 1;
        }
    }
}