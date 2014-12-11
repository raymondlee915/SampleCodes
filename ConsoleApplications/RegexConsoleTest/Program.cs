using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexConsoleTest
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    string pattern = "[\"']images/([^/.]*.(png|jpg))[\"']";
        //    Regex imgeRegex = new Regex(pattern, RegexOptions.IgnoreCase);

        //    string source = "fdkf sdkfjsdf <img src='images/name.jpg'/> asdfsdf sdfasdf sdkfjsdf <img src='images/name2.jpg'/> asdfsdf ";
        //    var result = imgeRegex.Matches(source);
        //    foreach(var item in result)
        //    {
        //        var match = item as Match;
        //        Console.WriteLine(match.Groups[1]);
        //    }

        //    Console.ReadKey();
        //}

        static void Main(string[] args)
        {
            string pattern = "<img\\s[^>]*src=[\"\']{1}([^\"']+)";
            Regex imgeRegex = new Regex(pattern, RegexOptions.IgnoreCase);

            string source = @"<div class=""sg-unit sg-col-first sg-colspan-1"" style=""font: 13px/20px WOL_Reg, &quot;Segoe UI&quot;, Tahoma, Helvetica, sans-serif; width: 227px; text-align: left; color: rgb(80, 80, 80); text-transform: none; text-indent: 0px; letter-spacing: normal; margin-left: 0px; word-spacing: 0px; vertical-align: top; display: inline-block; white-space: normal; font-size-adjust: none; font-stretch: normal; -webkit-text-stroke-width: 0px;"">
<div class=""section sectionNormal"" style=""display: inline; min-height: 0px;"">
<div>
<h4>Step 3</h4>

<p>Tap or click <strong>Pin to Start</strong> or <strong>Pin to taskbar</strong>. The apps you pinned will appear at the end of your Start screen or desktop taskbar.</p>
</div>
</div>
</div>

<div class=""sg-unit sg-colspan-3"" style=""font: 13px/20px WOL_Reg, &quot;Segoe UI&quot;, Tahoma, Helvetica, sans-serif; width: 741px; text-align: left; color: rgb(80, 80, 80); text-transform: none; text-indent: 0px; letter-spacing: normal; margin-left: 29.93px; word-spacing: 0px; vertical-align: top; display: inline-block; white-space: normal; font-size-adjust: none; font-stretch: normal; -webkit-text-stroke-width: 0px;"">
<div class=""section sectionNormal lastElement"" style=""margin-bottom: 0px; display: inline; min-height: 0px;"">
<div>
<div class=""para lastElement"" style=""color: rgb(80, 80, 80); line-height: 20px; font-size: 13px; margin-bottom: 0px;""><img alt=""Pin options"" class=""embedObject standalone"" src=""http://res2.windows.microsoft.com/resbox/en/6.3/2013-win81ga/44153aa8-8bc6-4e0e-9a68-d405c05225a5_28.png"" style=""border-image:none; border:currentColor; height:197px; max-width:100%; width:281px"" /></div>
</div>
</div>
</div>";
            var result = imgeRegex.Matches(source);
            foreach (var item in result)
            {
                var match = item as Match;
                Console.WriteLine(match.Groups[1]);
            }

            Console.ReadKey();
        }
    }
}
