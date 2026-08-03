using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Services;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class YetenekController : Controller
    {
        private readonly IKullaniciService _kullaniciService;

        public YetenekController(IKullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }

       
        public IActionResult Yetenekler()
        {
            var kategoriler = _kullaniciService.GetYetenekKategorileri();
            return View(kategoriler);
        }

       
        [HttpGet]
        public IActionResult Ekle()
        {
            ViewBag.Kategoriler = _kullaniciService.GetYetenekKategorileri();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Ekle(string yetenek, int? yetenek_kategorileri_id, string? yeniKategoriAd)
        {
            bool sonuc = _kullaniciService.YetenekEkle(yetenek, yetenek_kategorileri_id, yeniKategoriAd);

            if (sonuc)
            {
                return RedirectToAction("Yetenekler", "Yetenek", new { area = "Admin" });
            }

            ViewBag.Hata = "Yetenek eklenirken bir hata oluştu!";
            ViewBag.Kategoriler = _kullaniciService.GetYetenekKategorileri();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Sil(int id)
        {
            _kullaniciService.YetenekSil(id);
            return RedirectToAction("Yetenekler", "Yetenek", new { area = "Admin" });
        }
    }
}
