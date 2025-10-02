using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ERP_SalonNamestaja.Models;

public partial class SalonNamestajaErpContext : DbContext
{
    public SalonNamestajaErpContext()
    {
    }

    public SalonNamestajaErpContext(DbContextOptions<SalonNamestajaErpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Kategorija> Kategorijas { get; set; }

    public virtual DbSet<Korisnik> Korisniks { get; set; }

    public virtual DbSet<Korpa> Korpas { get; set; }

    public virtual DbSet<Porudzbina> Porudzbinas { get; set; }

    public virtual DbSet<Proizvod> Proizvods { get; set; }

    public virtual DbSet<Proizvodjac> Proizvodjacs { get; set; }

    public virtual DbSet<Prostorija> Prostorijas { get; set; }

    public virtual DbSet<StavkaKorpe> StavkaKorpes { get; set; }

    public virtual DbSet<StavkaPorudzbine> StavkaPorudzbines { get; set; }

    public virtual DbSet<Transakcija> Transakcijas { get; set; }

    public virtual DbSet<Uloga> Ulogas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress; Database=SalonNamestajaERP;Trusted_Connection=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kategorija>(entity =>
        {
            entity.HasKey(e => e.KategorijaId).HasName("PK__Kategori__487607FB8B09D698");

            entity.ToTable("Kategorija");

            entity.Property(e => e.KategorijaId).HasColumnName("kategorija_id");
            entity.Property(e => e.NazivKat)
                .HasMaxLength(20)
                .HasColumnName("nazivKat");
            entity.Property(e => e.ProstorijaId).HasColumnName("prostorija_id");

            entity.HasOne(d => d.Prostorija).WithMany(p => p.Kategorijas)
                .HasForeignKey(d => d.ProstorijaId)
                .HasConstraintName("FK_Kategorija_Prostorija");
        });

        modelBuilder.Entity<Korisnik>(entity =>
        {
            entity.HasKey(e => e.KorisnikId).HasName("PK__Korisnik__B84D9F5634A2B912");

            entity.ToTable("Korisnik");

            entity.Property(e => e.KorisnikId).HasColumnName("korisnik_id");
            entity.Property(e => e.Adresa)
                .HasMaxLength(100)
                .HasColumnName("adresa");
            entity.Property(e => e.Email)
                .HasMaxLength(25)
                .HasColumnName("email");
            entity.Property(e => e.Ime)
                .HasMaxLength(25)
                .HasColumnName("ime");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(256)
                .HasColumnName("password_hash");
            entity.Property(e => e.PasswordSalt)
                .HasMaxLength(256)
                .HasColumnName("password_salt");
            entity.Property(e => e.Prezime)
                .HasMaxLength(25)
                .HasColumnName("prezime");
            entity.Property(e => e.Telefon)
                .HasMaxLength(15)
                .HasColumnName("telefon");
            entity.Property(e => e.UlogaId).HasColumnName("uloga_id");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.Uloga).WithMany(p => p.Korisniks)
                .HasForeignKey(d => d.UlogaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Korisnik__uloga___398D8EEE");
        });

        modelBuilder.Entity<Korpa>(entity =>
        {
            entity.ToTable("Korpa");

            entity.Property(e => e.KorpaId).HasColumnName("korpa_id");
            entity.Property(e => e.KorisnikId).HasColumnName("korisnik_id");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.Korpas)
                .HasForeignKey(d => d.KorisnikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Korpa_Korisnik");
        });

        modelBuilder.Entity<Porudzbina>(entity =>
        {
            entity.HasKey(e => e.PorudzbinaId).HasName("PK__Porudzbi__14368C0AE0D51252");

            entity.ToTable("Porudzbina");

            entity.Property(e => e.PorudzbinaId).HasColumnName("porudzbina_id");
            entity.Property(e => e.AdresaIsporuke)
                .HasMaxLength(100)
                .HasColumnName("adresaIsporuke");
            entity.Property(e => e.DatumKreiranja).HasColumnName("datumKreiranja");
            entity.Property(e => e.KorisnikId).HasColumnName("korisnik_id");
            entity.Property(e => e.UkupnaCena).HasColumnName("ukupnaCena");
            entity.Property(e => e.VremeKreiranja).HasColumnName("vremeKreiranja");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.Porudzbinas)
                .HasForeignKey(d => d.KorisnikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Porudzbina_Korisnik");
        });

        modelBuilder.Entity<Proizvod>(entity =>
        {
            entity.HasKey(e => e.ProizvodId).HasName("PK__Proizvod__E52BF3543F48D777");

            entity.ToTable("Proizvod");

            entity.Property(e => e.ProizvodId).HasColumnName("proizvod_id");
            entity.Property(e => e.Cena).HasColumnName("cena");
            entity.Property(e => e.DatumDodavanja)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("datum_dodavanja");
            entity.Property(e => e.KategorijaId).HasColumnName("kategorija_id");
            entity.Property(e => e.Materijal)
                .HasMaxLength(30)
                .HasColumnName("materijal");
            entity.Property(e => e.Naziv)
                .HasMaxLength(100)
                .HasColumnName("naziv");
            entity.Property(e => e.Opis)
                .HasMaxLength(500)
                .HasColumnName("opis");
            entity.Property(e => e.ProizvodjacId).HasColumnName("proizvodjac_id");
            entity.Property(e => e.SifraProizvod)
                .HasMaxLength(20)
                .HasColumnName("sifraProizvod");
            entity.Property(e => e.SlikaUrl)
                .HasMaxLength(255)
                .HasColumnName("slika_url");
            entity.Property(e => e.Stanje).HasColumnName("stanje");
            entity.Property(e => e.StatusAktivan)
                .HasDefaultValue(true)
                .HasColumnName("status_aktivan");

            entity.HasOne(d => d.Kategorija).WithMany(p => p.Proizvods)
                .HasForeignKey(d => d.KategorijaId)
                .HasConstraintName("FK_Proizvod_Kategorija");

            entity.HasOne(d => d.Proizvodjac).WithMany(p => p.Proizvods)
                .HasForeignKey(d => d.ProizvodjacId)
                .HasConstraintName("FK_Proizvod_Proizvodjac");
        });

        modelBuilder.Entity<Proizvodjac>(entity =>
        {
            entity.HasKey(e => e.ProizvodjacId).HasName("PK__Proizvod__DD4E5AFA8468D820");

            entity.ToTable("Proizvodjac");

            entity.Property(e => e.ProizvodjacId).HasColumnName("proizvodjac_id");
            entity.Property(e => e.Naziv)
                .HasMaxLength(20)
                .HasColumnName("naziv");
        });

        modelBuilder.Entity<Prostorija>(entity =>
        {
            entity.HasKey(e => e.ProstorijaId).HasName("PK__Prostori__30BBABB14FD8E1B4");

            entity.ToTable("Prostorija");

            entity.Property(e => e.ProstorijaId).HasColumnName("prostorija_id");
            entity.Property(e => e.NazivPr)
                .HasMaxLength(20)
                .HasColumnName("nazivPr");
        });

        modelBuilder.Entity<StavkaKorpe>(entity =>
        {
            entity.HasKey(e => e.StavkaId);

            entity.ToTable("Stavka_Korpe");

            entity.Property(e => e.StavkaId).HasColumnName("stavka_id");
            entity.Property(e => e.Kolicina).HasColumnName("kolicina");
            entity.Property(e => e.KorpaId).HasColumnName("korpa_id");
            entity.Property(e => e.ProizvodId).HasColumnName("proizvod_id");

            entity.HasOne(d => d.Korpa).WithMany(p => p.StavkaKorpes)
                .HasForeignKey(d => d.KorpaId)
                .HasConstraintName("FK_StavkaKorpe_Korpa");

            entity.HasOne(d => d.Proizvod).WithMany(p => p.StavkaKorpes)
                .HasForeignKey(d => d.ProizvodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StavkaKorpe_Proizvod");
        });

        modelBuilder.Entity<StavkaPorudzbine>(entity =>
        {
            entity.HasKey(e => new { e.ProizvodId, e.PorudzbinaId });

            entity.ToTable("Stavka_Porudzbine");

            entity.Property(e => e.ProizvodId).HasColumnName("proizvod_id");
            entity.Property(e => e.PorudzbinaId).HasColumnName("porudzbina_id");
            entity.Property(e => e.Cena).HasColumnName("cena");
            entity.Property(e => e.Kolicina).HasColumnName("kolicina");

            entity.HasOne(d => d.Porudzbina).WithMany(p => p.StavkaPorudzbines)
                .HasForeignKey(d => d.PorudzbinaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Stavka_Porudzbine_Porudzbina");

            entity.HasOne(d => d.Proizvod).WithMany(p => p.StavkaPorudzbines)
                .HasForeignKey(d => d.ProizvodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Stavka_Porudzbine_Proizvod");
        });

        modelBuilder.Entity<Transakcija>(entity =>
        {
            entity.HasKey(e => e.TransakcijaId).HasName("PK__Transakc__0F8FB1174CF20C91");

            entity.ToTable("Transakcija");

            entity.Property(e => e.TransakcijaId).HasColumnName("transakcija_id");
            entity.Property(e => e.Datum)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("datum");
            entity.Property(e => e.Iznos)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("iznos");
            entity.Property(e => e.PorudzbinaId).HasColumnName("porudzbina_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.StripeId)
                .HasMaxLength(100)
                .HasColumnName("stripe_id");

            entity.HasOne(d => d.Porudzbina).WithMany(p => p.Transakcijas)
                .HasForeignKey(d => d.PorudzbinaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transakci__porud__5535A963");
        });

        modelBuilder.Entity<Uloga>(entity =>
        {
            entity.HasKey(e => e.UlogaId).HasName("PK__Uloga__03C8E0D82CF51D9D");

            entity.ToTable("Uloga");

            entity.Property(e => e.UlogaId).HasColumnName("uloga_id");
            entity.Property(e => e.Naziv)
                .HasMaxLength(50)
                .HasColumnName("naziv");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
