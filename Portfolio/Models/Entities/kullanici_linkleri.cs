namespace Portfolio.Models.Entities;

public class kullanici_linkleri
{
    public int id { get; set; }
    
    public int kullanici_id { get; set; }
    public required string baslik { get; set; }
    public required string url { get; set; }

    public virtual kullanici? kullanici { get; set; }
}