using Microsoft.AspNetCore.Mvc;
using Portfolio.Services;

namespace Portfolio.Areas.Admin.ViewComponents
{
    
    public class AdminProfileViewComponent : ViewComponent
    {
        private readonly IKullaniciService _kullaniciService;

        public AdminProfileViewComponent(IKullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }

       
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var kullanici = _kullaniciService.GetKullaniciWithDetails();

            
            return View(kullanici);
        }
    }
}