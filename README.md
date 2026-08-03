# ASP.NET Core 10 Portfolio & Admin Dashboard

Bu proje, **ASP.NET Core 10 MVC** mimarisi ve **PostgreSQL** veritabanı kullanılarak geliştirilmiş; kişisel portfolyo sunumu ile dinamik içerik yönetimini (Admin Paneli) birleştiren modern bir web uygulamasıdır.

---

### Ziyaretçi Arayüzü
- **Dinamik Biyografi:** Veritabanından canlı çekilen unvan, hakkımda ve profil bilgileri.
- **Duyurular Bölümü:** Admin panelinden eklenen güncel duyuruların canlı listelenmesi.
- **Projeler Portfolyosu:** Yapılan projelerin detaylı açıklamaları.
- **Yetenekler Kategori Yapısı:** Frontend, Backend, Veritabanı vb. kategorilere ayrılmış yetenekler.
- **İletişim & Teklif Formu:** Ziyaretçilerin doğrudan ücret teklifi ve mesaj gönderebilmesi.

### Admin Paneli
- **Gelen Teklifler Tablosu:** Ziyaretçilerin gönderdiği teklif ve mesajların canlı takibi.
- **Duyuru Yönetimi:** Yeni duyuru paylaşma, düzenleme ve silme.
- **Proje Yönetimi:** Portfolyoya yeni projeler ekleme ve silme.
- **Yetenek Yönetimi:** Yeni yetenek ve yetenek kategorileri oluşturma.
- **Profil & Fotoğraf Güncelleme:** Sunucuya dinamik profil fotoğrafı yükleme.
- **Bağımsız ViewComponent:** Admin profil bileşeninin dinamik modüler mimarisi.

---

### Teknolojiler

- **Backend:** C#, ASP.NET Core 10.0 (MVC Framework)
- **Veritabanı:** PostgreSQL, Entity Framework Core
- **Frontend & Tema:** HTML5, CSS3, JavaScript, SB Admin 2 (Bootstrap)
- **Konteynerleştirme:** Docker & Dockerfile (Multi-stage build)

---

### Yerelde Çalıştırma

```bash
# 1. Projeyi klonlayın
git clone https://github.com/EnesCanbulat/Portfolio.git

# 2. Proje klasörüne gidin
cd Portfolio/Portfolio

# 3. Bağımlılıkları yükleyin ve çalıştırın
dotnet restore
dotnet run
```

#### Docker İle Çalıştırma

```bash
# 1. Docker imajını derleyin
docker build -t portfolio-app .

# 2. Konteyneri çalıştırın
docker run -p 8080:8080 portfolio-app
```
