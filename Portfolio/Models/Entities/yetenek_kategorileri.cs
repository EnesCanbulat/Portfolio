namespace Portfolio.Models.Entities;

public class yetenek_kategorileri
{
    public int id { get; set; }

    public int kullanici_id { get; set; }

    public required string kategori { get; set; }

    public virtual kullanici? kullanici { get; set; }

    public virtual ICollection<yetenekler> yetenekler { get; set; } = new List<yetenekler>();
}