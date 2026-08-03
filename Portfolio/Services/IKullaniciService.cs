using Portfolio.Models.Entities;

namespace Portfolio.Services
{
    public interface IKullaniciService
    {
        kullanici? GetKullaniciWithDetails();

        kullanici Login(string kullanici_adi, string sifre);
        bool TeklifKaydet(string sirket, string eposta, string mesaj, decimal? ucret);

        bool DuyuruEkle(string baslik, string kategori, string icerik);

        bool DuyuruSil(int id);

        bool ProjeEkle(string proje, string aciklama);

        bool ProjeSil(int id);

        List<yetenek_kategorileri> GetYetenekKategorileri();

        bool YetenekEkle(string yetenek, int? yetenek_kategorileri_id, string? yeniKategoriAd);

        bool YetenekSil(int id);

        bool ProfilGuncelle(string isim, string soyisim, string unvan, string hakkimda, string? fotoUrl);
    }
}
