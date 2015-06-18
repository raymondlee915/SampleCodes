using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ja-JP");
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ja-JP");

            string pattern = "^[\u4e00-\u9fa5]";
            Regex imgeRegex = new Regex(pattern, RegexOptions.IgnoreCase);
            byte second = 0x30;
            byte first = 0xA1;
            int from = 0X30a1;
            int end = 0x30fe;
            byte[] chars = new byte[end - from + 1];
            for (int i = 0; i < chars.Length; i++)
            {
                if(i%2 == 0)
                {
                    chars[i] = first++;
                }
                else
                {
                    chars[i] = second;
                }
            }
           
            string source = @"津小瀬";
            byte[] bytes = Encoding.Default.GetBytes(source);
            Encoding encoder = Encoding.Unicode;
            byte[] unicodes = Encoding.Convert(Encoding.Default, encoder, bytes);

            var converted = encoder.GetString(chars);
            Console.WriteLine(converted);

            //foreach (var item in source)
            //{
            //    Console.WriteLine("{0:X000}", Convert.ToInt32(item));
            //}


            //foreach (var item in converted)
            //{
            //    Console.WriteLine("{0:X000}", Convert.ToInt32(item));
            //}

            Console.WriteLine(imgeRegex.IsMatch(source));

            Console.WriteLine("Done");

            // Test();

            Console.ReadKey();
        }

        private static void Test()
        {
            //英文字符串
            string str_en = "Welcome to the Encoding world.";
            //简体中文
            string str_cn = "欢迎来到编码世界！";
            //繁体中文
            string str_tw = "歡迎來到編碼世界";

            Encoding defaultEncoding = Encoding.Default;
            Console.WriteLine("默认编码：{0}", defaultEncoding.BodyName);


            Encoding dstEncoding = null;
            //ASCII码
            Console.WriteLine("----ASCII编码----");
            dstEncoding = Encoding.ASCII;
            OutputByEncoding(defaultEncoding, dstEncoding, str_en);
            OutputByEncoding(defaultEncoding, dstEncoding, str_cn);
            OutputByEncoding(defaultEncoding, dstEncoding, str_tw);

            OutputBoundary();

            //GB2312
            Console.WriteLine("----GB2312编码----");
            dstEncoding = Encoding.GetEncoding("GB2312");
            OutputByEncoding(defaultEncoding, dstEncoding, str_en);
            OutputByEncoding(defaultEncoding, dstEncoding, str_cn);
            OutputByEncoding(defaultEncoding, dstEncoding, str_tw);

            OutputBoundary();

            //BIG5
            Console.WriteLine("----BIG5编码----");
            dstEncoding = Encoding.GetEncoding("BIG5");
            OutputByEncoding(defaultEncoding, dstEncoding, str_en);
            OutputByEncoding(defaultEncoding, dstEncoding, str_cn);
            OutputByEncoding(defaultEncoding, dstEncoding, str_tw);

            OutputBoundary();

            //Unicode
            Console.WriteLine("----Unicode编码----");
            dstEncoding = Encoding.Unicode;
            OutputByEncoding(defaultEncoding, dstEncoding, str_en);
            OutputByEncoding(defaultEncoding, dstEncoding, str_cn);
            OutputByEncoding(defaultEncoding, dstEncoding, str_tw);

            OutputBoundary();

            //UTF8
            Console.WriteLine("----UTF8编码----");
            dstEncoding = Encoding.UTF8;
            OutputByEncoding(defaultEncoding, dstEncoding, str_en);
            OutputByEncoding(defaultEncoding, dstEncoding, str_cn);
            OutputByEncoding(defaultEncoding, dstEncoding, str_tw);

            Console.ReadKey();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="srcEncoding">原编码</param>
        /// <param name="dstEncoding">目标编码</param>
        /// <param name="srcBytes">原</param>
        public static void OutputByEncoding(Encoding srcEncoding, Encoding dstEncoding, string srcStr)
        {
            byte[] srcBytes = srcEncoding.GetBytes(srcStr);
            Console.WriteLine("Encoding.GetBytes: {0}", BitConverter.ToString(srcBytes));
            byte[] bytes = Encoding.Convert(srcEncoding, dstEncoding, srcBytes);
            Console.WriteLine("Encoding.GetBytes: {0}", BitConverter.ToString(bytes));
            string result = dstEncoding.GetString(bytes);
            Console.WriteLine("Encoding.GetString: {0}", result);
        }
        /// <summary>
        /// 分割线
        /// </summary>
        public static void OutputBoundary()
        {
            Console.WriteLine("------------------------------------");
        }
    }
}
