using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class AishuController : Controller
    {
        // GET: Aishu
        public ActionResult Index()
        {
            ViewBag.Time = DateTime.Now.ToString();
            return RedirectToAction("Suki","Aishu");
        }
        public ActionResult Suki()
        {
            //ViewData["CurrentTime"] = DateTime.Now.ToString();
            ViewBag.Time= DateTime.Now.ToString();
            return View("Myfirstpage");
        }
    }
}