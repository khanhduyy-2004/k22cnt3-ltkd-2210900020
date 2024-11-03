using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNTT3_LeTranKhanhDuy_2210900020.Controllers
{
    public class LtkdHomeController : Controller
    {
        public ActionResult LtkdIndex()
        {
            return View();
        }

        public ActionResult LtkdAbout()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult LtkdContact()
        {
            ViewBag.Msv = "2210900020.";
            ViewBag.Fullname = "Lê Trần Khánh Duy.";
            return View();
        }
    }
}