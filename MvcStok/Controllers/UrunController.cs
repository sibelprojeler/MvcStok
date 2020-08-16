using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using System.Data.Entity;


namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult UrunListele()
        {
            var degerler = db.TBL_URUNLER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degerler = (from i in db.TBL_KATEGORI.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View(); }

        [HttpPost]
        public ActionResult YeniUrun(TBL_URUNLER u1)
        {
            var ktg = db.TBL_KATEGORI.Where(m => m.KATEGORIID == u1.TBL_KATEGORI.KATEGORIID).FirstOrDefault();
            u1.TBL_KATEGORI = ktg;
            db.TBL_URUNLER.Add(u1);
            db.SaveChanges();
            return RedirectToAction("UrunListele");
        }

        public ActionResult SİL(int id)
        {
            var urn = db.TBL_URUNLER.Find(id);
            db.TBL_URUNLER.Remove(urn);
            db.SaveChanges();
            return RedirectToAction("UrunListele");
                }

        public ActionResult UrunGetir(int id)
        { var urn = db.TBL_URUNLER.Find(id);
           List<SelectListItem> degerler = (from i in db.TBL_KATEGORI.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View("UrunGetir",urn);
        }

        public ActionResult Guncelle (TBL_URUNLER p1)
        {
            var urn = db.TBL_URUNLER.Find(p1.URUNID);
            urn.URUNAD = p1.URUNAD;
            //urn.TBL_KATEGORI.KATGORIAD = p1.TBL_KATEGORI.KATGORIAD;
            var ktg = db.TBL_KATEGORI.Where(m => m.KATEGORIID == p1.TBL_KATEGORI.KATEGORIID).FirstOrDefault();
            urn.URUNKATEGORI = ktg.KATEGORIID;
            urn.URUNMARKA = p1.URUNMARKA;
            urn.FİYAT = p1.FİYAT;
            urn.STOK = p1.STOK;
            db.SaveChanges();
            return RedirectToAction("UrunListele");
        }

    }
}