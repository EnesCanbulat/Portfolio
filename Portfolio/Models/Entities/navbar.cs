namespace Portfolio.Models.Entities;

public class navbar
{
    public int id { get; set; }

    public int kullanici_id { get; set; }
    public required string title { get; set; }
    public required string href { get; set; }

  
    public int sira { get; set; }
    public virtual kullanici? kullanici { get; set; }
}