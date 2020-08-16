using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class SatisController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult PopUpEkleme()
        {
            return View();
        }

        public ActionResult Yardım()
        {
            return View();

        }
        [HttpGet]
        public ActionResult YeniSatıs()

        { return View(); }

        [HttpPost]
        public ActionResult YeniSatıs(TBL_SATIS p)
        { db.TBL_SATIS.Add(p);
            db.SaveChanges();
            return View("PopUpEkleme"); }


    }
}