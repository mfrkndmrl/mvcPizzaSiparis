using NewPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using NewPizza.ViewModel;
using System.IO;

namespace NewPizza.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            List<Siparis> siparisler = new List<Siparis>();
            siparisler = db.Sipariss.Include(s=>s.Adres).ToList();
            return View(siparisler);
        }
        public ActionResult SiparisDetay(int id)
        {
            Siparis siparis = new Siparis();
            siparis = db.Sipariss.Where(s => s.Id == id).FirstOrDefault();

            List<SiparisDetay> siparisDetay = new List<SiparisDetay>();
            siparisDetay = db.SiparisDetays.Include(s => s.Siparis.Adres).Include(s=>s.Urun).Where(s => s.SiparisId == id).ToList();

            SiparisSiparisDetayViewModel siparisSiparisDetay = new SiparisSiparisDetayViewModel
            {
                  Siparis= siparis, SiparisDetaylari = siparisDetay
            };

            return View(siparisSiparisDetay);
        }
        public ActionResult Onay(int id)
        {
            var siparis = db.Sipariss.Where(s => s.Id == id).FirstOrDefault();
            siparis.SiparisOnay = true;

            db.Entry(siparis).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }
        public ActionResult FileUpload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase file, string id)
        {
            if (file != null)
            {
                
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/images"), pic);
                // file is uploaded
                file.SaveAs(path);
                string dosyaAdi = Path.GetFileName(path);
                dosyaAdi = "/images/" + dosyaAdi;
                int idsi = Int32.Parse(id);
                var urun = db.Uruns.Where(u => u.Id == idsi).FirstOrDefault();
                urun.FotoAdres = dosyaAdi;
                db.Entry(urun).State = EntityState.Modified;
                db.SaveChanges();

                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }

            }
            // after successfully uploading redirect the user
            return RedirectToAction("Index", "Uruns");
        }
    }
}