namespace Portfolio.Models.Entities;

public class projeler
{
    public int id { get; set; }
    public int kullanici_id { get; set; }

    public required string proje { get; set; }
    public required string aciklama { get; set; }

    public virtual kullanici? kullanici { get; set; }
}