using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models.Entities;
using Portfolio.Services;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DuyuruController : Controller
    {
        private readonly IKullaniciService _kullaniciService;

        public DuyuruController(IKullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }

        
        [HttpGet]
        public IActionResult Duyurular()
        {
            var kullanici = _kullaniciService.GetKullaniciWithDetails();
            var duyuruListesi = kullanici?.duyurular?.OrderByDescending(d => d.gonderitarihi).ToList();

            return View(duyuruListesi);
        }

        
        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Ekle(string baslik, string kategori, string icerik)
        {
            bool sonuc = _kullaniciService.DuyuruEkle(baslik, kategori, icerik);

            if (sonuc)
            {
               
                return RedirectToAction("Duyurular", "Duyuru", new { area = "Admin" });
            }

            ViewBag.Hata = "Duyuru eklenirken bir hata oluştu!";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Sil(int id)
        {
            _kullaniciService.DuyuruSil(id);
            return RedirectToAction("Duyurular", "Duyuru", new { area = "Admin" });
        }
    }
}