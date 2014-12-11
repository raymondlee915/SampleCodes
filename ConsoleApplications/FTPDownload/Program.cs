using FTPDownload.JigSaw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FTPDownload
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var webClient = new WebClient())
            //{
            //   // var result = webClient.DownloadString("ftp://ftp.dell.com/Manuals/all-products/esuprt_laptop/esuprt_xps_laptop/");
            //   //Console.WriteLine(result);

            //    webClient.DownloadFile("ftp://ftp.dell.com/Manuals/all-products/esuprt_laptop/esuprt_xps_laptop/xps-11-9p33_Reference%20Guide2_en-us.pdf", "test.pdf");
            //}

            AssetServiceSoapClient client = new AssetServiceSoapClient();
            var result = client.GetAssetInformation(Guid.NewGuid(), "LC", "264M1Y1");
            foreach(var item in result){
                Console.WriteLine(item.AssetHeaderData.SystemType);
            }

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
