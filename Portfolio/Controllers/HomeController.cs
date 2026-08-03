using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Models.ViewModels;
using Portfolio.Services;
using System.Diagnostics;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly IKullaniciService _kullaniciService;

        public HomeController(IKullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }

        public IActionResult Index()
        {
            var kullanici = _kullaniciService.GetKullaniciWithDetails();

            var model = new HomeViewModel
            {
                kullanici = kullanici,
                duyurular = kullanici?.duyurular?.OrderByDescending(d => d.gonderitarihi).ToList(),
                kullanici_linkleri = kullanici?.kullanici_linkleri?.ToList(),
                navbar = kullanici?.navbar?.OrderBy(n => n.sira).ToList(),
                projeler = kullanici?.projeler?.ToList(),
                yetenek_kategorileri = kullanici?.yetenek_kategorileri?.ToList()
            };

            
            ViewBag.AdSoyad = kullanici != null
                ? $"{kullanici.isim} {kullanici.soyisim}"
                : "Portfolio";

            ViewBag.SosyalLinkler = model.kullanici_linkleri;

            return View(model);
        }

        [HttpPost]
        public IActionResult TeklifGonder(string sirket, string eposta, string mesaj, decimal? ucret)
        {
            var sonuc = _kullaniciService.TeklifKaydet(sirket, eposta, mesaj, ucret);
            if (!sonuc) return BadRequest();

            TempData["FormMesaji"] = "Teklifiniz başarıyla gönderildi!";
            return Redirect("/#iletisim");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}