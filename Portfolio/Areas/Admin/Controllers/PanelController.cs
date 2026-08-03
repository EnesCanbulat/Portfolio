using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Services;

namespace Portfolio.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize]
    public class PanelController : Controller
    {
      
        private readonly IKullaniciService _kullaniciservice;

        public PanelController(IKullaniciService kullaniciService)
        {
            _kullaniciservice = kullaniciService;
        }

                public IActionResult Panel()
        {
            var kullanici = _kullaniciservice.GetKullaniciWithDetails();

            return View();
        }

             
        
          
        }
    }

