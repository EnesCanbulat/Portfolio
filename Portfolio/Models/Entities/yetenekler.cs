namespace Portfolio.Models.Entities;

public class yetenekler
{
    public int id { get; set; }

    public int kullanici_id { get; set; }
    public int yetenek_kategorileri_id { get; set; }
    public required string yetenek { get; set; }

    public virtual kullanici? kullanici { get; set; }
    public virtual yetenek_kategorileri? yetenek_kategori { get; set; }
}