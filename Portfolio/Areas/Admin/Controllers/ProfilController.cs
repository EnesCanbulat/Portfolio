using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Services;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProfilController : Controller
    {
        private readonly IKullaniciService _kullaniciService;

        public ProfilController(IKullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }

       
        [HttpGet]
        public IActionResult Profil()
        {
            var kullanici = _kullaniciService.GetKullaniciWithDetails();
            return View(kullanici);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profil(string isim, string soyisim, string unvan, string hakkimda, IFormFile? profilFoto)
        {
            string? kayitliFotoYolu = null;

            
            if (profilFoto != null && profilFoto.Length > 0)
            {
              
                var uploadsKlasoru = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                if (!Directory.Exists(uploadsKlasoru))
                {
                    Directory.CreateDirectory(uploadsKlasoru);
                }

               
                var dosyaAdi = Guid.NewGuid().ToString() + Path.GetExtension(profilFoto.FileName);
                var dosyaYuklemeYolu = Path.Combine(uploadsKlasoru, dosyaAdi);

                
                using (var stream = new FileStream(dosyaYuklemeYolu, FileMode.Create))
                {
                    await profilFoto.CopyToAsync(stream);
                }

                kayitliFotoYolu = "uploads/" + dosyaAdi;
            }

            
            bool sonuc = _kullaniciService.ProfilGuncelle(isim, soyisim, unvan, hakkimda, kayitliFotoYolu);

            if (sonuc)
            {
                ViewBag.Mesaj = "Profil bilgileriniz ve fotoğrafınız başarıyla güncellendi!";
            }
            else
            {
                ViewBag.Hata = "Profil güncellenirken bir hata oluştu!";
            }

            var guncelKullanici = _kullaniciService.GetKullaniciWithDetails();
            return View(guncelKullanici);
        }
    }
}