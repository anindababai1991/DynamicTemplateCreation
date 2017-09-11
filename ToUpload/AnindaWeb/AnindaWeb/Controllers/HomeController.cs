using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnindaWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

#if (AboutPage)
        public ActionResult About()
        {
            ViewBag.Message = "Aninda's description page.";

            return View();
        }
#endif

#if (ContactPage)
        public ActionResult Contact()
        {
            ViewBag.Message = "Aninda's Contact Page";

            return View();
        }
#endif
    }
}