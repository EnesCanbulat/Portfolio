using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using Portfolio.Models.Entities;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Portfolio.Services
{
    public class KullaniciService : IKullaniciService
    {
        private readonly AppDbContext _context;

        public KullaniciService(AppDbContext context)
        {
            _context = context;
        }

        public kullanici? GetKullaniciWithDetails()
        {
            return _context.kullanici
                .Include(k => k.kullanici_linkleri)
                .Include(k => k.projeler)
                .Include(k => k.duyurular)
                .Include(k => k.navbar)
                .Include(k => k.teklifler)
                .Include(k => k.yetenek_kategorileri)
                    .ThenInclude(yk => yk.yetenekler)
                .FirstOrDefault();
        }

        public bool TeklifKaydet(string sirket, string eposta, string mesaj, decimal? ucret)
        {
            var kullanici = _context.kullanici.FirstOrDefault();
            if (kullanici == null) return false;

            var teklif = new teklifler
            {
                kullanici_id = kullanici.id,
                sirket = sirket,
                eposta = eposta,
                mesaj = mesaj,
                ucret = ucret
            };

            _context.teklifler.Add(teklif);
            _context.SaveChanges();
            return true;
        }



        public kullanici? Login(string kullanici_adi, string sifre)
        {
            var kullanici = _context.kullanici.FirstOrDefault(k => k.kullanici_adi == kullanici_adi);
            if (kullanici == null) return null;

            
            if (kullanici.sifre == sifre) return kullanici;

          
            try
            {
                if (BCrypt.Net.BCrypt.Verify(sifre, kullanici.sifre)) return kullanici;
            }
            catch
            {
                
            }

            return null;
        }

        public bool DuyuruEkle(string baslik, string kategori, string icerik)
        {
            var kullanici = _context.kullanici.FirstOrDefault();
            if (kullanici == null) return false;

            var duyuru = new Portfolio.Models.Entities.duyurular
            {
                kullanici_id = kullanici.id,
                baslik = baslik,
                kategori = kategori,
                icerik = icerik,
                gonderitarihi = DateTime.UtcNow
            };

            _context.duyurular.Add(duyuru);
            _context.SaveChanges();
            return true;
        }

        public bool DuyuruSil(int id)
        {
            var silinecekDuyuru = _context.duyurular.FirstOrDefault(d => d.id == id);
            if (silinecekDuyuru == null) return false;

            _context.duyurular.Remove(silinecekDuyuru);
            _context.SaveChanges();
            return true;
        }

        public bool ProjeEkle(string proje, string aciklama)
        {
            var kullanici = _context.kullanici.FirstOrDefault();
            if (kullanici == null) return false;

            var projeler = new Portfolio.Models.Entities.projeler
            {

                kullanici_id = kullanici.id,
                proje = proje,
                aciklama = aciklama,


            };

            _context.projeler.Add(projeler);
            _context.SaveChanges();
            return true;


        }

        public bool ProjeSil(int id) { 

            var SilinecekProje = _context.projeler.FirstOrDefault(p => p.id == id);
            if (SilinecekProje == null) return false;

            _context.projeler.Remove(SilinecekProje);
            _context.SaveChanges();
            return true;
        }

        public List<yetenek_kategorileri> GetYetenekKategorileri()
        {
            return _context.yetenek_kategorileri.Include(yk => yk.yetenekler).ToList();
        }

        public bool YetenekEkle(string yetenek, int? yetenek_kategorileri_id, string? yeniKategoriAd)
        {
            var kullanici = _context.kullanici.FirstOrDefault();
            if (kullanici == null) return false;

            int katId = 0;

            if (!string.IsNullOrWhiteSpace(yeniKategoriAd))
            {
                var varKategori = _context.yetenek_kategorileri
                    .FirstOrDefault(k => k.kategori.ToLower() == yeniKategoriAd.Trim().ToLower());

                if (varKategori != null)
                {
                    katId = varKategori.id;
                }
                else
                {
                    var yeniKat = new Portfolio.Models.Entities.yetenek_kategorileri
                    {
                        kullanici_id = kullanici.id,
                        kategori = yeniKategoriAd.Trim()
                    };
                    _context.yetenek_kategorileri.Add(yeniKat);
                    _context.SaveChanges();
                    katId = yeniKat.id;
                }
            }
            else if (yetenek_kategorileri_id.HasValue && yetenek_kategorileri_id.Value > 0)
            {
                katId = yetenek_kategorileri_id.Value;
            }
            else
            {
                var genelKat = _context.yetenek_kategorileri.FirstOrDefault(k => k.kategori == "Genel");
                if (genelKat == null)
                {
                    genelKat = new Portfolio.Models.Entities.yetenek_kategorileri
                    {
                        kullanici_id = kullanici.id,
                        kategori = "Genel"
                    };
                    _context.yetenek_kategorileri.Add(genelKat);
                    _context.SaveChanges();
                }
                katId = genelKat.id;
            }

            var yeniYetenek = new Portfolio.Models.Entities.yetenekler
            {
                kullanici_id = kullanici.id,
                yetenek_kategorileri_id = katId,
                yetenek = yetenek
            };

            _context.yetenekler.Add(yeniYetenek);
            _context.SaveChanges();
            return true;
        }

        public bool YetenekSil(int id)
        {
            var silinecekYetenek = _context.yetenekler.FirstOrDefault(y => y.id == id);
            if (silinecekYetenek == null) return false;

            _context.yetenekler.Remove(silinecekYetenek);
            _context.SaveChanges();
            return true;
        }

        public bool ProfilGuncelle(string isim, string soyisim, string unvan, string hakkimda, string? fotoUrl)
        {
            var kullanici = _context.kullanici.FirstOrDefault();
            if (kullanici == null) return false;

            kullanici.isim = isim;
            kullanici.soyisim = soyisim;
            kullanici.unvan = unvan;
            kullanici.hakkimda = hakkimda;

            if (!string.IsNullOrEmpty(fotoUrl))
            {
                kullanici.foto_url = fotoUrl;
            }

            _context.SaveChanges();
            return true;
        }
    }
}

