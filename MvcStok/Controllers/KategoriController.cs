using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();

        public ActionResult KategoriListe(int sayfa=1)
        {
            //var degerler = db.TBL_KATEGORI.ToList();
            var degerler = db.TBL_KATEGORI.ToList().ToPagedList(sayfa,4);
            return View(degerler);
        }

       [HttpGet]
        public ActionResult YeniKategori()
        { return View();}

        [HttpPost]
        public ActionResult YeniKategori(TBL_KATEGORI p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.TBL_KATEGORI.Add(p1);
            db.SaveChanges();
            return RedirectToAction("KategoriListe");
        }

        public ActionResult SİL(int id)
        {
            var kategori=db.TBL_KATEGORI.Find(id);
            db.TBL_KATEGORI.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("KategoriListe");

               }

        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBL_KATEGORI.Find(id);
            return View("KategoriGetir", ktgr);
       }

        public ActionResult güncelle(TBL_KATEGORI p1)
        {
            var ktgr = db.TBL_KATEGORI.Find(p1.KATEGORIID);
            ktgr.KATGORIAD = p1.KATGORIAD;
            db.SaveChanges();
            return RedirectToAction("KategoriListe");
        }
    }
}