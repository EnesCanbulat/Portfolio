namespace Portfolio.Models.Entities;

public class duyurular
{
    public int id { get; set; }

    public int kullanici_id { get; set; }

    public required string baslik { get; set; }

    public required string icerik { get; set; }

    public DateTime gonderitarihi { get; set; } = DateTime.Now;
    public string? kategori { get; set; }

  
    public virtual kullanici? kullanici { get; set; }
}