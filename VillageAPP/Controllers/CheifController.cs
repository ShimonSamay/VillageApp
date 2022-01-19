using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VillageAPP.Controllers
{
    public class CheifController : Controller
    {
        
        public ActionResult Welcome()
        {
            ViewBag.message = "Welcome Cheif";
            return View();
        }
    }
}