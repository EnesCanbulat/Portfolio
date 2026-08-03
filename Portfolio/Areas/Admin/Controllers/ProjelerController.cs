using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Services;

namespace Portfolio.Areas.Admin.Controllers


{
    [Area("Admin")]
    [Authorize]
    public class ProjeController : Controller
    {
        private readonly IKullaniciService _kullaniciService;

        public ProjeController(IKullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }

        public IActionResult Projeler() 
        {
            var kullanici = _kullaniciService.GetKullaniciWithDetails();
            var ProjeListesi = kullanici?.projeler?.ToList();

            return View(ProjeListesi);


        }

        [HttpGet]
        
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Ekle(string proje, string aciklama)
        {
            bool sonuc = _kullaniciService.ProjeEkle(proje, aciklama);

            if (sonuc)
            {

                return RedirectToAction("Projeler", "Proje", new { area = "Admin" });

            }
            ViewBag.Hata = "Proje eklenirken bir hata oluştu";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
           public IActionResult Sil(int id)
        {
            _kullaniciService.ProjeSil(id);
            return RedirectToAction("Projeler", "Proje", new { area = "Admin" });

        }
    }

}
