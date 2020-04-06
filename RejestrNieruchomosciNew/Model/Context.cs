using System.Configuration;
using Microsoft.EntityFrameworkCore;
using RejestrNieruchomosciNew.Model;


namespace RejestrNieruchomosciNew
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<GminaSlo> GminaSlo { get; set; }
        public virtual DbSet<Obreb> Obreb { get; set; }
        public virtual DbSet<Dzialka> Dzialka { get; set; }

        public virtual DbSet<Budynek> Budynek { get; set; }
        public virtual DbSet<Dzialka_Budynek> Dzialka_Budynek { get; set; }
        public virtual DbSet<Wladanie> Wladanie { get; set; }
        public virtual DbSet<InnePrawa> InnePrawa { get; set; }

        public virtual DbSet<PlatnoscUW> PlatnoscUW { get; set; }
        public virtual DbSet<PlatnoscInnePrawa> PlatnoscInnePrawa { get; set; }

        public virtual DbSet<NazwaCzynnosciSlo> NazwaCzynnosciSlo { get; set; }
        public virtual DbSet<RodzajDokumentuSlo> RodzajDokumentuSlo { get; set; }
        public virtual DbSet<FormaWladaniaSlo> FormaWladaniaSlo { get; set; }
        public virtual DbSet<RodzajInnegoPrawaSlo> RodzajInnegoPrawaSlo { get; set; }

        public virtual DbSet<Uzytki> Uzytki { get; set; }
        public virtual DbSet<UzytkiSlo> UzytkiSlo { get; set; }

        public virtual DbSet<UliceSlo> UliceSlo { get; set; }

        public virtual DbSet<Zagosp> Zagosp { get; set; }
        public virtual DbSet<ZagospStatusSlo> ZagospStatusSlo { get; set; }
        public virtual DbSet<ZagospFunkcjaSlo> ZagospFunkcjaSlo { get; set; }
        
        public virtual DbSet<NadzorKonserwSlo> NadzorKonserwSlo { get; set; }

        public virtual DbSet<Transakcje> Transakcje { get; set; }
        
        public virtual DbSet<DecyzjeAdministracyjne> DecyzjeAdministracyjne { get; set; }

        public virtual DbQuery<CelNabycia> CelNabyciaView { get; set; }
        public virtual DbQuery<Podmiot> PodmiotView { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["conStrRaf"].ConnectionString);
                //optionsBuilder.EnableSensitiveDataLogging(true);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dzialka_Budynek>()
                .HasKey(bc => new { bc.DzialkaId, bc.BudynekId });

            modelBuilder.Entity<Dzialka_Budynek>()
                .HasOne(bc => bc.Dzialka)
                .WithMany(b => b.Dzialka_Budynek)
                .HasForeignKey(bc => bc.DzialkaId);

            modelBuilder.Entity<Dzialka_Budynek>()
                .HasOne(bc => bc.Budynek)
                .WithMany(c => c.Dzialka_Budynek)
                .HasForeignKey(bc => bc.BudynekId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Dzialka>()
               .HasOne<Obreb>(a => a.Obreb)
               .WithMany(a => a.Dzialka)
               .HasForeignKey(a => a.ObrebId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Dzialka>()
                .HasIndex("Numer", "ObrebId")
                .IsUnique();

            modelBuilder.Entity<Wladanie>()
               .HasOne<Dzialka>(a=>a.Dzialka)
               .WithMany(a=>a.Wladanie)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PlatnoscUW>()
                .HasKey(k=>k.PlatnoscUWId);

            modelBuilder.Entity<PlatnoscUW>()
              .HasOne<Dzialka>(a => a.Dzialka)
              .WithOne(a => a.PlatnoscUW)
              .HasForeignKey("PlatnoscUW", "DzialkaId")
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PlatnoscInnePrawa>()
                .HasKey(k => k.PlatnoscInnePrawaId);

            modelBuilder.Entity<PlatnoscInnePrawa>()
              .HasOne<InnePrawa>(a => a.InnePrawa)
              .WithOne(a => a.PlatnoscInnePrawa)
              .HasForeignKey("PlatnoscInnePrawa", "InnePrawaId")
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RodzajDokumentuSlo>().HasData(
                new RodzajDokumentuSlo() { RodzajDokumentuSloId = 1, Nazwa = "-" },
                new RodzajDokumentuSlo() { RodzajDokumentuSloId = 2, Nazwa = "Akt notarialny" },
                new RodzajDokumentuSlo() { RodzajDokumentuSloId = 3, Nazwa = "Postanowienie sądu" }
            );

            modelBuilder.Entity<RodzajTransakcjiSlo>().HasData(
               new RodzajTransakcjiSlo() { RodzajTransakcjiSloId = 1, Nazwa = "-" },
               new RodzajTransakcjiSlo() { RodzajTransakcjiSloId = 2, Nazwa = "Kupno" },
               new RodzajTransakcjiSlo() { RodzajTransakcjiSloId = 3, Nazwa = "Sprzedaż" }
           );

            modelBuilder.Entity<FormaWladaniaSlo>().HasData(
              new FormaWladaniaSlo() { FormaWladaniaSloId = 1, Nazwa = "-" },
              new FormaWladaniaSlo() { FormaWladaniaSloId = 2, Nazwa = "Własność" },
              new FormaWladaniaSlo() { FormaWladaniaSloId = 3, Nazwa = "UW" }
          );

            modelBuilder.Entity<NadzorKonserwSlo>().HasData(
              new NadzorKonserwSlo() { NadzorKonserwSloId = 1, Nazwa = "-" },
              new NadzorKonserwSlo() { NadzorKonserwSloId = 2, Nazwa = "Nie" },
              new NadzorKonserwSlo() { NadzorKonserwSloId = 3, Nazwa = "Tak" }
          );

            modelBuilder.Entity<NazwaCzynnosciSlo>().HasData(
             new NazwaCzynnosciSlo() { NazwaCzynnosciSloId = 1, Nazwa = "-" },
             new NazwaCzynnosciSlo() { NazwaCzynnosciSloId = 2, Nazwa = "Zakup" },
             new NazwaCzynnosciSlo() { NazwaCzynnosciSloId = 3, Nazwa = "Aport" }
         );

            modelBuilder.Entity<RodzajInnegoPrawaSlo>().HasData(
            new RodzajInnegoPrawaSlo() { RodzajInnegoPrawaSloId = 1, Nazwa = "-" },
            new RodzajInnegoPrawaSlo() { RodzajInnegoPrawaSloId = 2, Nazwa = "dzierżawa" },
            new RodzajInnegoPrawaSlo() { RodzajInnegoPrawaSloId = 3, Nazwa = "najem" },
            new RodzajInnegoPrawaSlo() { RodzajInnegoPrawaSloId = 4, Nazwa = "użyczenie" },
            new RodzajInnegoPrawaSlo() { RodzajInnegoPrawaSloId = 5, Nazwa = "służebność" },
            new RodzajInnegoPrawaSlo() { RodzajInnegoPrawaSloId = 6, Nazwa = "czasowe zajęcie" },
            new RodzajInnegoPrawaSlo() { RodzajInnegoPrawaSloId = 7, Nazwa = "bezumowne" }
        );

            modelBuilder.Entity<ZagospFunkcjaSlo>().HasData(
                new ZagospFunkcjaSlo() {  ZagospFunkcjaSloId = 1, Nazwa = "-"},
                new ZagospFunkcjaSlo() {  ZagospFunkcjaSloId = 2, Nazwa = "społeczna" },
                new ZagospFunkcjaSlo() {  ZagospFunkcjaSloId = 3, Nazwa = "użytkowa" },
                new ZagospFunkcjaSlo() {  ZagospFunkcjaSloId = 4, Nazwa = "finansowa" },
                new ZagospFunkcjaSlo() { ZagospFunkcjaSloId = 5, Nazwa = "mieszana" }
        );

            modelBuilder.Entity<ZagospStatusSlo>().HasData(
                new ZagospStatusSlo() { ZagospStatusSloId = 1, Nazwa = "-" },
                new ZagospStatusSlo() { ZagospStatusSloId = 2, Nazwa = "wodociągowa" },
                new ZagospStatusSlo() { ZagospStatusSloId = 3, Nazwa = "sanitarna" },
                new ZagospStatusSlo() { ZagospStatusSloId = 4, Nazwa = "komercyjna" },
                new ZagospStatusSlo() { ZagospStatusSloId = 5, Nazwa = "mieszana" }
        );
            
            modelBuilder.Entity<UzytkiSlo>().HasData(
             new UzytkiSlo() { UzytkiSloId = 1, Nazwa = "-" },
             new UzytkiSlo() { UzytkiSloId = 2, Nazwa = "R" },
             new UzytkiSlo() { UzytkiSloId = 3, Nazwa = "S" },
             new UzytkiSlo() { UzytkiSloId = 4, Nazwa = "Ł" },
             new UzytkiSlo() { UzytkiSloId = 5, Nazwa = "Ps" },
             new UzytkiSlo() { UzytkiSloId = 6, Nazwa = "Br" },
             new UzytkiSlo() { UzytkiSloId = 7, Nazwa = "Wsr" },
             new UzytkiSlo() { UzytkiSloId = 8, Nazwa = "W" },
             new UzytkiSlo() { UzytkiSloId = 9, Nazwa = "Lzr" },
             new UzytkiSlo() { UzytkiSloId = 10, Nazwa = "N" },
             new UzytkiSlo() { UzytkiSloId = 11, Nazwa = "Ls" },
             new UzytkiSlo() { UzytkiSloId = 12, Nazwa = "Lz" },
             new UzytkiSlo() { UzytkiSloId = 13, Nazwa = "B" },
             new UzytkiSlo() { UzytkiSloId = 14, Nazwa = "Ba" },
             new UzytkiSlo() { UzytkiSloId = 15, Nazwa = "Bi" },
             new UzytkiSlo() { UzytkiSloId = 16, Nazwa = "Bp" },
             new UzytkiSlo() { UzytkiSloId = 17, Nazwa = "Bz" },
             new UzytkiSlo() { UzytkiSloId = 18, Nazwa = "K" },
             new UzytkiSlo() { UzytkiSloId = 19, Nazwa = "dr" },
             new UzytkiSlo() { UzytkiSloId = 20, Nazwa = "Tk" },
             new UzytkiSlo() { UzytkiSloId = 21, Nazwa = "Ti" },
             new UzytkiSlo() { UzytkiSloId = 22, Nazwa = "Tp" },
             new UzytkiSlo() { UzytkiSloId = 23, Nazwa = "E-Ws" },
             new UzytkiSlo() { UzytkiSloId = 24, Nazwa = "E-Wp" },
             new UzytkiSlo() { UzytkiSloId = 25, Nazwa = "E-Ls" },
             new UzytkiSlo() { UzytkiSloId = 26, Nazwa = "E-Lz" },
             new UzytkiSlo() { UzytkiSloId = 27, Nazwa = "E-N" },
             new UzytkiSlo() { UzytkiSloId = 28, Nazwa = "E-Ps" },
             new UzytkiSlo() { UzytkiSloId = 29, Nazwa = "E-R" },
             new UzytkiSlo() { UzytkiSloId = 30, Nazwa = "E-Ł" },
             new UzytkiSlo() { UzytkiSloId = 31, Nazwa = "E-Lzr" },
             new UzytkiSlo() { UzytkiSloId = 32, Nazwa = "E-W" },
             new UzytkiSlo() { UzytkiSloId = 33, Nazwa = "Wm" },
             new UzytkiSlo() { UzytkiSloId = 34, Nazwa = "Wp" },
             new UzytkiSlo() { UzytkiSloId = 35, Nazwa = "Ws" },
             new UzytkiSlo() { UzytkiSloId = 36, Nazwa = "Tr" }
        );

            //modelBuilder.Entity<GminaSlo>().HasData(
            //   new GminaSlo() { GminaSloId = 1, Nazwa = "miasto Gdańsk" },
            //   new GminaSlo() { GminaSloId = 2, Nazwa = "miasto Sopot" },
            //   new GminaSlo() { GminaSloId = 3, Nazwa = "miasto Pruszcz Gdański" },
            //   new GminaSlo() { GminaSloId = 4, Nazwa = "gmina Gdańsk" },
            //   new GminaSlo() { GminaSloId = 5, Nazwa = "gmina Pruszcz Gdański" },
            //   new GminaSlo() { GminaSloId = 6, Nazwa = "gmina Żukowo" },
            //   new GminaSlo() { GminaSloId = 7, Nazwa = "gmina Kolbudy" }
            //);

            //modelBuilder.Entity<Obreb>().HasData(
            //        new Obreb() { ObrebId = 1, Nazwa = "010", GminaSloId = 1 },
            //        new Obreb() { ObrebId = 2, Nazwa = "020", GminaSloId = 1 },
            //        new Obreb() { ObrebId = 3, Nazwa = "030", GminaSloId = 1 },
            //        new Obreb() { ObrebId = 4, Nazwa = "040", GminaSloId = 1 },
            //        new Obreb() { ObrebId = 5, Nazwa = "050", GminaSloId = 1 },
            //        new Obreb() { ObrebId = 6, Nazwa = "060", GminaSloId = 1 },
            //        new Obreb() { ObrebId = 7, Nazwa = "070", GminaSloId = 1 },
            //        new Obreb() { ObrebId = 8, Nazwa = "080", GminaSloId = 1 },
            //        new Obreb() { ObrebId = 9, Nazwa = "090", GminaSloId = 1 },
            //        new Obreb() { ObrebId = 10, Nazwa = "100", GminaSloId = 1 },
            //        new Obreb() { ObrebId = 11, Nazwa = "110", GminaSloId = 1 },
            //        new Obreb() { ObrebId = 12, Nazwa = "120", GminaSloId = 1 },
            //        new Obreb() { ObrebId = 13, Nazwa = "130", GminaSloId = 1 },
            //        new Obreb() { ObrebId = 14, Nazwa = "010", GminaSloId = 2 },
            //        new Obreb() { ObrebId = 15, Nazwa = "020", GminaSloId = 2 },
            //        new Obreb() { ObrebId = 16, Nazwa = "030", GminaSloId = 2 },
            //        new Obreb() { ObrebId = 17, Nazwa = "040", GminaSloId = 2 },
            //        new Obreb() { ObrebId = 18, Nazwa = "050", GminaSloId = 2 },
            //        new Obreb() { ObrebId = 19, Nazwa = "060", GminaSloId = 2 },
            //        new Obreb() { ObrebId = 20, Nazwa = "070", GminaSloId = 2 },
            //        new Obreb() { ObrebId = 21, Nazwa = "010", GminaSloId = 3 },
            //        new Obreb() { ObrebId = 22, Nazwa = "020", GminaSloId = 3 },
            //        new Obreb() { ObrebId = 23, Nazwa = "030", GminaSloId = 4 },
            //        new Obreb() { ObrebId = 24, Nazwa = "040", GminaSloId = 4 },
            //        new Obreb() { ObrebId = 25, Nazwa = "050", GminaSloId = 4 }
            //    );

          #region Added automatically
            //modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            //modelBuilder.Entity<Dzialka>(entity =>
            //{
            //    entity.ToTable("dzialka");

            //    entity.HasIndex(e => new { e.Numer, e.ObrebId })
            //        .HasName("dzialkaConstr")
            //        .IsUnique();

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.InnePrawa).HasColumnName("innePrawa");

            //    entity.Property(e => e.Kwakt)
            //        .HasColumnName("KWakt")
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Kwzrob)
            //        .HasColumnName("KWzrob")
            //        .HasMaxLength(20)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Numer)
            //        .IsRequired()
            //        .HasColumnName("numer")
            //        .HasMaxLength(13)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ObrebId).HasColumnName("obrebID");

            //    entity.Property(e => e.Pow)
            //        .HasColumnName("pow")
            //        .HasColumnType("decimal(18, 4)");
            //});

            //modelBuilder.Entity<DzielnicaSlo>(entity =>
            //{
            //    entity.ToTable("dzielnica_slo");

            //    entity.HasIndex(e => e.Nazwa)
            //        .HasName("UQ__dzielnic__F072DFBECA1285A7")
            //        .IsUnique();

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Nazwa)
            //        .IsRequired()
            //        .HasColumnName("nazwa")
            //        .HasMaxLength(23)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<FormaWladaniaSlo>(entity =>
            //{
            //    entity.ToTable("formaWladania_slo");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Nazwa)
            //        .IsRequired()
            //        .HasColumnName("nazwa")
            //        .HasMaxLength(30)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<GminaSlo>(entity =>
            //{
            //    entity.ToTable("gmina_slo");

            //    entity.HasIndex(e => e.Nazwa)
            //        .HasName("UQ__gmina_sl__F072DFBE4DD5526D")
            //        .IsUnique();

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Nazwa)
            //        .HasColumnName("nazwa")
            //        .HasMaxLength(23)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<InnePrawa>(entity =>
            //{
            //    entity.ToTable("innePrawa");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.DataDokumentuNab)
            //        .HasColumnName("dataDokumentuNab")
            //        .HasColumnType("date");

            //    entity.Property(e => e.DataDokumentuZb)
            //        .HasColumnName("dataDokumentuZb")
            //        .HasColumnType("date");

            //    entity.Property(e => e.DataObowiazywaniaDo)
            //        .HasColumnName("dataObowiazywaniaDO")
            //        .HasColumnType("date");

            //    entity.Property(e => e.DataObowiazywaniaOd)
            //        .HasColumnName("dataObowiazywaniaOD")
            //        .HasColumnType("date");

            //    entity.Property(e => e.DataWpisuKwnab)
            //        .HasColumnName("dataWpisuKWNab")
            //        .HasColumnType("date");

            //    entity.Property(e => e.DataWpisuKwzb)
            //        .HasColumnName("dataWpisuKWZb")
            //        .HasColumnType("date");

            //    entity.Property(e => e.DecyzjaData)
            //        .HasColumnName("decyzjaData")
            //        .HasColumnType("date");

            //    entity.Property(e => e.DecyzjaNr)
            //        .HasColumnName("decyzjaNr")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DecyzjaOrganId).HasColumnName("decyzjaOrganID");

            //    entity.Property(e => e.DecyzjaPrzedmiot)
            //        .HasColumnName("decyzjaPrzedmiot")
            //        .HasMaxLength(500)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DoPrzekazania)
            //        .HasColumnName("doPrzekazania")
            //        .HasColumnType("date");

            //    entity.Property(e => e.DoZwrotnegoPrzekazania)
            //        .HasColumnName("doZwrotnegoPrzekazania")
            //        .HasColumnType("date");

            //    entity.Property(e => e.DzialkaId).HasColumnName("dzialkaID");

            //    entity.Property(e => e.InnePrawaId).HasColumnName("innePrawaID");

            //    entity.Property(e => e.NazwaCzynnosciNabId).HasColumnName("nazwaCzynnosciNabID");

            //    entity.Property(e => e.NazwaCzynnosciZbId).HasColumnName("nazwaCzynnosciZbID");

            //    entity.Property(e => e.NrDokumentuNab)
            //        .HasColumnName("nrDokumentuNab")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.NrDokumentuZb)
            //        .HasColumnName("nrDokumentuZb")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Okres).HasColumnName("okres");

            //    entity.Property(e => e.PodmiotId).HasColumnName("podmiotID");

            //    entity.Property(e => e.PrzedstawicielId).HasColumnName("przedstawicielID");

            //    entity.Property(e => e.RodzajDokumentuNabId).HasColumnName("rodzajDokumentuNabID");

            //    entity.Property(e => e.RodzajDokumentuZbId).HasColumnName("rodzajDokumentuZbID");

            //    entity.Property(e => e.Stawka).HasColumnName("stawka");

            //    entity.Property(e => e.TytulDokumentuNab)
            //        .HasColumnName("tytulDokumentuNab")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.TytulDokumentuZb)
            //        .HasColumnName("tytulDokumentuZb")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Wartosc)
            //        .HasColumnName("wartosc")
            //        .HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.WarunkiRealizacji)
            //        .HasColumnName("warunkiRealizacji")
            //        .HasMaxLength(500)
            //        .IsUnicode(false);

            //    entity.HasOne(d => d.Dzialka)
            //        .WithMany(p => p.InnePrawaNavigation)
            //        .HasForeignKey(d => d.DzialkaId)
            //        .HasConstraintName("FK_dzialka_innePrawa");
            //});

            //modelBuilder.Entity<NazwaCzynnosciSlo>(entity =>
            //{
            //    entity.ToTable("nazwaCzynnosci_slo");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Nazwa)
            //        .IsRequired()
            //        .HasColumnName("nazwa")
            //        .HasMaxLength(30)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<Obreb>(entity =>
            //{
            //    entity.ToTable("obreb");

            //    entity.HasIndex(e => new { e.GminaId, e.Nazwa })
            //        .HasName("CONSTRAINTobreb")
            //        .IsUnique();

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.GminaId).HasColumnName("gminaID");

            //    entity.Property(e => e.Nazwa)
            //        .HasColumnName("nazwa")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.HasOne(d => d.Gmina)
            //        .WithMany(p => p.Obreb)
            //        .HasForeignKey(d => d.GminaId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_obreb_gmina_slo");
            //});

            //modelBuilder.Entity<ObrebSlo>(entity =>
            //{
            //    entity.ToTable("obreb_slo");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Nazwa)
            //        .HasColumnName("nazwa")
            //        .HasMaxLength(23)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<PlatnoscUw>(entity =>
            //{
            //    entity.ToTable("platnoscUW");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Okres).HasColumnName("okres");

            //    entity.Property(e => e.Stawka).HasColumnName("stawka");

            //    entity.Property(e => e.Wartosc).HasColumnName("wartosc");
            //});

            //modelBuilder.Entity<Podmiot>(entity =>
            //{
            //    entity.ToTable("podmiot");

            //    entity.HasIndex(e => new { e.Imie, e.Nazwisko, e.Nazwa })
            //        .HasName("podmiotConstr")
            //        .IsUnique();

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Adres)
            //        .HasColumnName("adres")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DataIn)
            //        .HasColumnName("dataIN")
            //        .HasColumnType("date")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.DataMod)
            //        .HasColumnName("dataMOD")
            //        .HasColumnType("date")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Email)
            //        .HasColumnName("email")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Imie)
            //        .HasColumnName("imie")
            //        .HasMaxLength(13)
            //        .IsUnicode(false)
            //        .HasDefaultValueSql("('-')");

            //    entity.Property(e => e.Nazwa)
            //        .HasColumnName("nazwa")
            //        .HasMaxLength(100)
            //        .IsUnicode(false)
            //        .HasDefaultValueSql("('-')");

            //    entity.Property(e => e.Nazwisko)
            //        .HasColumnName("nazwisko")
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .HasDefaultValueSql("('-')");

            //    entity.Property(e => e.NrTelefonu)
            //        .HasColumnName("nrTelefonu")
            //        .HasMaxLength(30)
            //        .IsUnicode(false);

            //    entity.Property(e => e.State)
            //        .HasColumnName("state")
            //        .HasDefaultValueSql("((3))");

            //    entity.Property(e => e.StatusId).HasColumnName("statusID");

            //    entity.Property(e => e.Uid).HasColumnName("UID");

            //    entity.HasOne(d => d.Status)
            //        .WithMany(p => p.Podmiot)
            //        .HasForeignKey(d => d.StatusId)
            //        .HasConstraintName("FK_podmiot_status_slo");
            //});

            //modelBuilder.Entity<RodzajDokumentuSlo>(entity =>
            //{
            //    entity.ToTable("rodzajDokumentu_slo");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Nazwa)
            //        .IsRequired()
            //        .HasColumnName("nazwa")
            //        .HasMaxLength(30)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<StatusSlo>(entity =>
            //{
            //    entity.ToTable("status_slo");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.Nazwa)
            //        .HasColumnName("nazwa")
            //        .HasMaxLength(23)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<Wladanie>(entity =>
            //{
            //    entity.ToTable("wladanie");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.DataDokumentu)
            //        .HasColumnName("dataDokumentu")
            //        .HasColumnType("date");

            //    entity.Property(e => e.DataObowiazywaniaDo)
            //        .HasColumnName("dataObowiazywaniaDO")
            //        .HasColumnType("date");

            //    entity.Property(e => e.DataObowiazywaniaOd)
            //        .HasColumnName("dataObowiazywaniaOD")
            //        .HasColumnType("date");

            //    entity.Property(e => e.DzialkaId).HasColumnName("dzialkaID");

            //    entity.Property(e => e.FormaWladaniaId).HasColumnName("formaWladaniaID");

            //    entity.Property(e => e.NazwaCzynnosciId).HasColumnName("nazwaCzynnosciID");

            //    entity.Property(e => e.Okres).HasColumnName("okres");

            //    entity.Property(e => e.PlatnoscUwid).HasColumnName("platnoscUWID");

            //    entity.Property(e => e.PodmiotId).HasColumnName("podmiotID");

            //    entity.Property(e => e.RodzajDokumentuId).HasColumnName("rodzajDokumentuID");

            //    entity.Property(e => e.Stawka).HasColumnName("stawka");

            //    entity.Property(e => e.TytulDokumentu)
            //        .HasColumnName("tytulDokumentu")
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Udzial)
            //        .HasColumnName("udzial")
            //        .HasMaxLength(13)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Wartosc)
            //        .HasColumnName("wartosc")
            //        .HasColumnType("decimal(18, 4)");

            //    entity.HasOne(d => d.Dzialka)
            //        .WithMany(p => p.Wladanie)
            //        .HasForeignKey(d => d.DzialkaId)
            //        .HasConstraintName("FK_dzialka_wladanie");

            //    entity.HasOne(d => d.FormaWladania)
            //        .WithMany(p => p.Wladanie)
            //        .HasForeignKey(d => d.FormaWladaniaId)
            //        .HasConstraintName("FK_wladanie_wladanie_slo");

            //    entity.HasOne(d => d.NazwaCzynnosci)
            //        .WithMany(p => p.Wladanie)
            //        .HasForeignKey(d => d.NazwaCzynnosciId)
            //        .HasConstraintName("FK_wladanie_nazwaCzynnosci_slo");

            //    entity.HasOne(d => d.PlatnoscUw)
            //        .WithMany(p => p.Wladanie)
            //        .HasForeignKey(d => d.PlatnoscUwid)
            //        .HasConstraintName("FK_wladanie_platnoscUW_slo");

            //    entity.HasOne(d => d.Podmiot)
            //        .WithMany(p => p.Wladanie)
            //        .HasForeignKey(d => d.PodmiotId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_wladanie_podmiot");

            //    entity.HasOne(d => d.RodzajDokumentu)
            //        .WithMany(p => p.Wladanie)
            //        .HasForeignKey(d => d.RodzajDokumentuId)
            //        .HasConstraintName("FK_wladanie_rodzajDokumentu_slo");
            //});
            #endregion
        }
    }
}
