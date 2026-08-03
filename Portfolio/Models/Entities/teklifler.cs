namespace Portfolio.Models.Entities;

public class teklifler
{
    public int id { get; set; }

    public int kullanici_id { get; set; }

    public required string sirket { get; set; }
    public required string eposta { get; set; }
    public required string mesaj { get; set; }

    public decimal? ucret { get; set; }
    public DateTime olusturulma_tarihi { get; set; } = DateTime.Now;

    public virtual kullanici? kullanici { get; set; }
}