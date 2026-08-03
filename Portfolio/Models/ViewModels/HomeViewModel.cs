using Portfolio.Models.Entities;

namespace Portfolio.Models.ViewModels
{
    public class HomeViewModel
    {
        public kullanici? kullanici { get; set; }
        public List<duyurular>? duyurular { get; set; }
        public List<kullanici_linkleri>? kullanici_linkleri { get; set; }
        public List<navbar>? navbar { get; set; }
        public List<projeler>? projeler { get; set; }
        public List<yetenek_kategorileri>? yetenek_kategorileri { get; set; }
    }
}
