using System.Transactions;
namespace Portfolio.Models.Entities
{

public class kullanici
{
    public int id { get; set; }
    public required string isim { get; set; }
    public required string soyisim { get; set; }
    public required string unvan { get; set; }
    public required string durum { get; set; }
    public required string iletisim { get; set; }

    public string? cv { get; set; }
    public string? foto_url { get; set; }
    public string? telefonno { get; set; }
    public string? hakkimda { get; set; }

    public required string kullanici_adi { get; set; }
    public required string sifre {  get; set; }


    public virtual ICollection<duyurular> duyurular { get; set; } = new List<duyurular>();
        public virtual ICollection<kullanici_linkleri> kullanici_linkleri { get; set; } = new List<kullanici_linkleri>();
        public virtual ICollection<navbar> navbar { get; set; } = new List<navbar>();

        public virtual ICollection<projeler> projeler { get; set; } = new List<projeler>();
      public virtual ICollection<teklifler> teklifler { get; set; } = new List<teklifler>();
   public virtual ICollection<yetenek_kategorileri> yetenek_kategorileri { get; set; } = new List<yetenek_kategorileri>();
    public virtual ICollection<yetenekler> yetenekler { get; set; } = new List<yetenekler>();
    }
}



    

