using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCTest.Controllers
{
    public class HomeController : Controller
    {
        public Task<ActionResult> Index()
        {
            var t = Utility.GetValue();
            //ViewData.Add("a", t);
            //return View();

            return t.ContinueWith<ActionResult>(_ => { ViewData.Add("a", _.Result); return View(); });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}