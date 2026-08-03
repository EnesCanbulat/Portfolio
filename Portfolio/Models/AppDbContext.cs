using Microsoft.EntityFrameworkCore;
using Portfolio.Models.Entities;

namespace Portfolio.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<kullanici> kullanici { get; set; }
    public DbSet<duyurular> duyurular { get; set; }
    public DbSet<kullanici_linkleri> kullanici_linkleri { get; set; }
    public DbSet<navbar> navbar { get; set; }
    public DbSet<projeler> projeler { get; set; }
    public DbSet<teklifler> teklifler { get; set; }
    public DbSet<yetenek_kategorileri> yetenek_kategorileri { get; set; }
    public DbSet<yetenekler> yetenekler { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("public");

        modelBuilder.Entity<kullanici>().ToTable("kullanici");
        modelBuilder.Entity<kullanici>()
            .Property(k => k.id)
            .HasColumnName("id");
        modelBuilder.Entity<duyurular>().ToTable("duyurular");
        modelBuilder.Entity<kullanici_linkleri>().ToTable("kullanici_linkleri");
        modelBuilder.Entity<navbar>().ToTable("navbar");
        modelBuilder.Entity<projeler>().ToTable("projeler");
        modelBuilder.Entity<teklifler>().ToTable("teklifler");
        modelBuilder.Entity<yetenek_kategorileri>().ToTable("yetenek_kategorileri");
        modelBuilder.Entity<yetenekler>().ToTable("yetenekler");

        modelBuilder.Entity<duyurular>()
          .HasOne(d => d.kullanici)
          .WithMany(k => k.duyurular)
          .HasForeignKey(d => d.kullanici_id)
          .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<kullanici_linkleri>()
            .HasOne(kl => kl.kullanici)
            .WithMany(k => k.kullanici_linkleri)
            .HasForeignKey(kl => kl.kullanici_id)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<navbar>()
            .HasOne(n => n.kullanici)
            .WithMany(k => k.navbar)
            .HasForeignKey(n => n.kullanici_id)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<projeler>()
            .HasOne(p => p.kullanici)
            .WithMany(k => k.projeler)
            .HasForeignKey(p => p.kullanici_id)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<teklifler>()
            .HasOne(t => t.kullanici)
            .WithMany(k => k.teklifler)
            .HasForeignKey(t => t.kullanici_id)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<yetenek_kategorileri>()
            .HasOne(yk => yk.kullanici)
            .WithMany(k => k.yetenek_kategorileri)
            .HasForeignKey(yk => yk.kullanici_id)
            .OnDelete(DeleteBehavior.Cascade);                            

        modelBuilder.Entity<yetenekler>()
            .HasOne(y => y.kullanici)
            .WithMany(k => k.yetenekler)
            .HasForeignKey(y => y.kullanici_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<yetenekler>()
            .HasOne(y => y.yetenek_kategori)
            .WithMany(yk => yk.yetenekler)
            .HasForeignKey(y => y.yetenek_kategorileri_id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}