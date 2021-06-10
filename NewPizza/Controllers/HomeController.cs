using NewPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using NewPizza.ViewModel;
using Microsoft.AspNet.Identity;

namespace NewPizza.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();  

        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
                //return RedirectToAction("../admin/index");
                return RedirectToAction("Index", "Admin");

            UrunSepetViewModel viewmodel = new UrunSepetViewModel();
            var userid= User.Identity.GetUserId();
            double toplam = 0;


            viewmodel.Urunler = db.Uruns.Include(u => u.Kategori).ToList();
            viewmodel.SepetUrunler = db.Sepets.Where(s => s.UserId == userid).ToList();

            //sepet toplam tutar hesaplanıyor

                
                foreach (var item in viewmodel.SepetUrunler)
                {

                    double fiyat = item.Adet * item.Urun.Fiyat;
                    toplam = toplam+fiyat;
                };
                
            
            ViewBag.Toplam = toplam;
            return View(viewmodel);
        }
        //[Authorize(Roles ="Musteri")]
        public ActionResult SepeteEkle()
        {
            return RedirectToAction("Index");

        }
        [Authorize]
        [HttpPost]
        public ActionResult SepeteEkle( FormCollection form)
        //public ActionResult SepeteEkle(FormCollection urun)
        {
            if (form["id"] != "")
            {
                var userid = User.Identity.GetUserId();
                Sepet sepet = new Sepet();
                int urunid = Int32.Parse(form["id"]);
                
                //aynı üründen varsa
                var mevcutUrun = db.Sepets.Where(u => u.UserId == userid).Where(p => p.UrunId == urunid).SingleOrDefault();
                if (mevcutUrun!=null)
                {
                    mevcutUrun.Adet = mevcutUrun.Adet + Int32.Parse(form["Adet"]);
                    mevcutUrun.UrunId = Int32.Parse(form["id"]);
                    mevcutUrun.UserId = userid;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    //aynı üründen yoksa
                    sepet.Adet = Int32.Parse(form["Adet"]);
                    sepet.UrunId = Int32.Parse(form["id"]);
                    sepet.UserId = userid;
                    db.Sepets.Add(sepet);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }
            else
                return RedirectToAction("Index");

        }
        [Authorize]
        public ActionResult SepettenUrunSil(int id)
        {
            var urun = db.Sepets.Where(s => s.Id == id).FirstOrDefault();
            db.Sepets.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult AdresSepet()
        {
            var adressepet = new AdresSepetViewModel();
            var userid = User.Identity.GetUserId();
            //List<Sepet> SepettekiUrunler = new List<Sepet>();
            adressepet.SepetUrunleri = db.Sepets.Include(s=>s.Urun).Where(s => s.UserId == userid).ToList();
            adressepet.Adresler = db.Adress.Where(s => s.UserId == userid).ToList();
            return View(adressepet);
        }
        [Authorize]
        public ActionResult AdresEkle()
        {

            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult AdresEkle([Bind(Include = "Id, AcikAdres, sehir, Ilce, UserId")] Adres adres)
        {
            var userid = User.Identity.GetUserId();

            Adres adresKaydet = new Adres();
            adresKaydet.AcikAdres = adres.AcikAdres;
            adresKaydet.Sehir = adres.Sehir;
            adresKaydet.Ilce = adres.Ilce;
            adresKaydet.UserId = userid;

            db.Adress.Add(adresKaydet);
            db.SaveChanges();
            return RedirectToAction("AdresSepet");
        }
        [Authorize]
        public ActionResult SiparisKaydet(int id)
        {
            //kullanıcı id
            var userid = User.Identity.GetUserId();
            //gonderilecek adres id
            var adresid = id;
            //Adres secilenAdres = db.Adress.Where(x => x.Id == id).FirstOrDefault();
            //urunler kayıt öncesi sepetten listeye aktarıldı

            //include yaparak urunleri de tablo ilişkisi ile alıyoruz
            List<Sepet> sepetUrunleri = db.Sepets.Include(s=>s.Urun).Where(s => s.UserId == userid).ToList();

            //siparis kaydı yapılıyor
            Siparis siparis = new Siparis();
            siparis.AdresId = adresid;
            siparis.UserId = userid;
            siparis.Tarih = DateTime.Now;
            db.Sipariss.Add(siparis);
            db.SaveChanges();

            int siparisid = siparis.Id; // orderin idsini aliyoruz

            //siparisdetay kısmı yapılıyor
            SiparisDetay siparisDetay = new SiparisDetay();
            foreach (var item in sepetUrunleri)
            {
                siparisDetay.Adet = item.Adet;
                siparisDetay.SiparisId = siparisid;
                siparisDetay.UrunId = item.UrunId;
                siparisDetay.Fiyat = (item.Adet * item.Urun.Fiyat);
                db.SiparisDetays.Add(siparisDetay);
                db.SaveChanges();

                //sepet urunleri siliniyor
                var silSepet = db.Sepets.Where(s => s.Id == item.Id).FirstOrDefault();
                db.Sepets.Remove(silSepet);
                db.SaveChanges();
            }


            //kayıt işleminden sonra sepetteki verilen silinir.

            return RedirectToAction("SiparisSonuc");
        }
        [Authorize]
        public ActionResult SiparisSonuc()
        {

            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}