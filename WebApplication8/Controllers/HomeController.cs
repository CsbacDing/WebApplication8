using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Filters;


namespace WebApplication8.Controllers
{
    
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        [CustomAuthorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [CustomAuthorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}