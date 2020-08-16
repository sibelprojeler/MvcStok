using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
       
        public ActionResult MusteriListele(string p)
        {
            var degerler = from d in db.TBL_MUSTERI select d;
         
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.MUSTERİAD.Contains(p) );
               
            }
            return View(degerler.ToList());
            //var degerler = db.TBL_MUSTERI.ToList();
            //return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        { return View(); }

        [HttpPost]
        public ActionResult YeniMusteri(TBL_MUSTERI m1)
        {
            db.TBL_MUSTERI.Add(m1);
            db.SaveChanges();
            return View("MusteriListele");
        }

        public ActionResult SİL(int id)
        {
            var musteri = db.TBL_MUSTERI.Find(id);
            db.TBL_MUSTERI.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("MusteriListele");

        }


        public ActionResult MusteriGetir(int id)
        {
            var mus = db.TBL_MUSTERI.Find(id);
            return View("MusteriGetir", mus);
        }

        public ActionResult Guncelle(TBL_MUSTERI p1)
        { var mus = db.TBL_MUSTERI.Find(p1.MUSTERIID);
            mus.MUSTERİAD = p1.MUSTERİAD;
            mus.MUSTERİSOYAD = p1.MUSTERİSOYAD;
            db.SaveChanges();
            return RedirectToAction("MusteriListele");
        }
    }
}