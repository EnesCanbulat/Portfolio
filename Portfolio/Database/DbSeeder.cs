using Portfolio.Models;
using Portfolio.Models.Entities;

namespace Portfolio.Database
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            // Kullanıcı Bilgileri
            var adminUser = context.kullanici.FirstOrDefault();
            if (adminUser == null)
            {
                adminUser = new kullanici
                {
                    isim = "Enes",
                    soyisim = "Canbulat",
                    unvan = "Junior Backend Developer",
                    durum = "Bilgisayar Mühendisi / Çalışmaya Hazır",
                    iletisim = "enescanbulat35@gmail.com",
                    hakkimda = "Bilgisayar Mühendisliği mezunu bir Yazılım Geliştiriciyim. Algoritma, veri yapıları, backend sistemleri ve veri odaklı uygulamalar üzerine pratik ve üretime hazır projeler geliştirmeye odaklanıyorum. Java, C#, Spring Boot, ASP.NET Core, PostgreSQL ve MySQL teknolojileriyle ölçeklenebilir backend çözümleri üretiyorum.",
                    foto_url = "assets/img/hero-bg.jpeg",
                    telefonno = "+90 507 099 28 98",
                    kullanici_adi = "admin",
                    sifre = "123456"
                };

                context.kullanici.Add(adminUser);
                context.SaveChanges();
            }
            else
            {
                bool guncellendi = false;
                if (string.IsNullOrEmpty(adminUser.kullanici_adi)) { adminUser.kullanici_adi = "admin"; guncellendi = true; }
                if (string.IsNullOrEmpty(adminUser.sifre)) { adminUser.sifre = "123456"; guncellendi = true; }
                if (guncellendi) context.SaveChanges();
            }

            // Yetenekler
            var backendKat = context.yetenek_kategorileri.FirstOrDefault(k => k.kategori == "Backend & Diller");
            if (backendKat == null)
            {
                backendKat = new yetenek_kategorileri { kullanici_id = adminUser.id, kategori = "Backend & Diller" };
                context.yetenek_kategorileri.Add(backendKat);
                context.SaveChanges();
            }

            var dbKat = context.yetenek_kategorileri.FirstOrDefault(k => k.kategori == "Veritabanı & Araçlar");
            if (dbKat == null)
            {
                dbKat = new yetenek_kategorileri { kullanici_id = adminUser.id, kategori = "Veritabanı & Araçlar" };
                context.yetenek_kategorileri.Add(dbKat);
                context.SaveChanges();
            }

            var testKat = context.yetenek_kategorileri.FirstOrDefault(k => k.kategori == "Test & Otomasyon");
            if (testKat == null)
            {
                testKat = new yetenek_kategorileri { kullanici_id = adminUser.id, kategori = "Test & Otomasyon" };
                context.yetenek_kategorileri.Add(testKat);
                context.SaveChanges();
            }

            var cvYetenekleri = new List<(int katId, string yetenekAd)>
            {
                (backendKat.id, "Java"),
                (backendKat.id, "C# / .NET"),
                (backendKat.id, "Spring Boot"),
                (backendKat.id, "ASP.NET Core 10.0"),
                (backendKat.id, "RESTful APIs & CRUD"),
                (dbKat.id, "PostgreSQL"),
                (dbKat.id, "MySQL"),
                (dbKat.id, "Git & GitHub"),
                (dbKat.id, "Docker & Docker Compose"),
                (testKat.id, "Selenium & Cucumber (BDD)"),
                (testKat.id, "CI/CD & GitHub Actions")
            };

            foreach (var y in cvYetenekleri)
            {
                if (!context.yetenekler.Any(yt => yt.yetenek == y.yetenekAd))
                {
                    context.yetenekler.Add(new yetenekler
                    {
                        kullanici_id = adminUser.id,
                        yetenek_kategorileri_id = y.katId,
                        yetenek = y.yetenekAd
                    });
                }
            }
            context.SaveChanges();

            // Projeler
            var cvProjeleri = new List<projeler>
            {
                new projeler 
                { 
                    kullanici_id = adminUser.id, 
                    proje = "Campus Data (Üniversite Atlası)", 
                    aciklama = "Üniversite adaylarının lisans programlarını filtreleyip karşılaştırabildiği full-stack web uygulaması. React 18 + TypeScript SPA, Spring Boot 3 / Java 17 REST API, JWT doğrulaması, PostgreSQL, Redis önbellekleme ve Leaflet harita entegrasyonu." 
                },
                new projeler 
                { 
                    kullanici_id = adminUser.id, 
                    proje = "ASP.NET Core Portfolio & Admin Dashboard", 
                    aciklama = "ASP.NET Core 10 MVC, PostgreSQL ve Docker kullanılarak geliştirilmiş; dinamik içerik yönetimi, teklif takibi ve profilleme özelliklerine sahip web uygulaması." 
                },
                new projeler 
                { 
                    kullanici_id = adminUser.id, 
                    proje = "Ticket System (Çağrı Merkezi Sistemi)", 
                    aciklama = "Spring Boot ve MySQL ile geliştirilmiş çağrı merkezi backend projesi. Bildirim sistemi, mesajlaşma, öncelik yönetimi ve durum takibi özelliklerini barındırır." 
                },
                new projeler 
                { 
                    kullanici_id = adminUser.id, 
                    proje = "Weather API - OpenWeatherMap Integration", 
                    aciklama = "Gerçek zamanlı hava durumu verileri ve iklim sınıflandırma bilgilerini bir araya getiren Spring Boot REST API çözümü." 
                },
                new projeler 
                { 
                    kullanici_id = adminUser.id, 
                    proje = "E-Commerce Test Automation Framework", 
                    aciklama = "Java, Selenium ve Cucumber kullanılarak geliştirilmiş, BDD yaklaşımı, Page Object Model ve GitHub Actions CI/CD entegrasyonu içeren test otomasyon mimarisi." 
                }
            };

            foreach (var prj in cvProjeleri)
            {
                if (!context.projeler.Any(p => p.proje == prj.proje))
                {
                    context.projeler.Add(prj);
                }
            }

            // Duyurular
            if (!context.duyurular.Any())
            {
                context.duyurular.Add(new duyurular 
                { 
                    kullanici_id = adminUser.id, 
                    baslik = "Portfolyo Sitem Yayında!", 
                    kategori = "Duyuru", 
                    icerik = "ASP.NET Core 10, PostgreSQL ve Docker mimarisiyle geliştirdiğim yeni kişisel web sitem ve admin panelim başarıyla yayınlandı.", 
                    gonderitarihi = DateTime.UtcNow 
                });
            }

            context.SaveChanges();
        }
    }
}
