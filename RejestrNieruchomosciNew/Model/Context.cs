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

        public virtual DbSet<UlicaSlo> UliceSlo { get; set; }

        public virtual DbSet<Lokal> Lokal { get; set; }

        public virtual DbSet<Adres> Adres { get; set; }

        public virtual DbSet<MiejscowoscSlo> MiejscowoscSlo { get; set; }

        public virtual DbSet<Zagosp> Zagosp { get; set; }
        public virtual DbSet<ZagospStatus> ZagospStatus { get; set; }
        public virtual DbSet<ZagospStatusSlo> ZagospStatusSlo { get; set; }
        public virtual DbSet<ZagospFunkcjaSlo> ZagospFunkcjaSlo { get; set; }

        public virtual DbSet<KonserwPrzyrodySlo> KonserwPrzyrodySlo { get; set; }
        public virtual DbSet<KonserwZabytkowSlo> KonserwZabytkowSlo { get; set; }

        public virtual DbSet<PrzedstawicielSlo> PrzedstawicielSlo { get; set; }

        public virtual DbSet<Transakcje> Transakcje { get; set; }

        public virtual DbSet<DecyzjeAdministracyjne> DecyzjeAdministracyjne { get; set; }

        public virtual DbSet<Lokal_Podmiot> Lokal_Podmiot { get; set; }

        public virtual DbQuery<CelNabycia> CelNabyciaView { get; set; }
        public virtual DbQuery<Podmiot> PodmiotView { get; set; }

        public virtual DbSet<User> User { get; set; }

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
            modelBuilder.Entity<Lokal_Podmiot>()
                .HasOne(bc => bc.Lokal)
                .WithMany(b => b.Lokal_Podmiot)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Lokal>()
                 .HasOne<Budynek>(a => a.Budynek)
                 .WithMany(a => a.Lokal)
                 .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Adres>()
                  .HasOne<Dzialka>(a => a.Dzialka)
                  .WithOne(a => a.Adres)
                  .HasForeignKey("Adres", "DzialkaId")
                  .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Budynek>()
               .HasOne<Adres>(a => a.Adres)
               .WithOne(a => a.Budynek)
               .HasForeignKey("Adres", "BudynekId")
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Adres>()
                .HasOne(m => m.MiejscowoscSlo)
                .WithMany(a => a.Adres)
                .HasForeignKey(am => am.MiejscowoscSloId);

            modelBuilder.Entity<Adres>()
                .HasOne(m => m.UlicaSlo)
                .WithMany(a => a.Adres)
                .HasForeignKey(am => am.UlicaSloId);

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
               .HasOne<Dzialka>(a => a.Dzialka)
               .WithMany(a => a.Wladanie)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PlatnoscUW>()
                .HasKey(k => k.PlatnoscUWId);

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

            modelBuilder.Entity<KonserwPrzyrodySlo>().HasData(
              new KonserwPrzyrodySlo() { KonserwPrzyrodySloId = 1, Nazwa = "-" },
              new KonserwPrzyrodySlo() { KonserwPrzyrodySloId = 2, Nazwa = "Nie" },
              new KonserwPrzyrodySlo() { KonserwPrzyrodySloId = 3, Nazwa = "Tak" }
          );

            modelBuilder.Entity<KonserwZabytkowSlo>().HasData(
               new KonserwZabytkowSlo() { KonserwZabytkowSloId = 1, Nazwa = "-" },
               new KonserwZabytkowSlo() { KonserwZabytkowSloId = 2, Nazwa = "rejestr zabytków" },
               new KonserwZabytkowSlo() { KonserwZabytkowSloId = 3, Nazwa = "Gminna Ewidencja Zabytków" },
               new KonserwZabytkowSlo() { KonserwZabytkowSloId = 4, Nazwa = "Wojewódzka Ewidencja Zabytków" },
               new KonserwZabytkowSlo() { KonserwZabytkowSloId = 5, Nazwa = "MPZP" }
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

        //    modelBuilder.Entity<ZagospFunkcjaSlo>().HasData(
        //        new ZagospFunkcjaSlo() { ZagospFunkcjaSloId = 1, Nazwa = "-" },
        //        new ZagospFunkcjaSlo() { ZagospFunkcjaSloId = 2, Nazwa = "społeczna" },
        //        new ZagospFunkcjaSlo() { ZagospFunkcjaSloId = 3, Nazwa = "użytkowa" },
        //        new ZagospFunkcjaSlo() { ZagospFunkcjaSloId = 4, Nazwa = "finansowa" },
        //        new ZagospFunkcjaSlo() { ZagospFunkcjaSloId = 5, Nazwa = "mieszana" }
        //);

        //    modelBuilder.Entity<ZagospStatusSlo>().HasData(
        //        new ZagospStatusSlo() { ZagospStatusSloId = 1, Nazwa = "-" },
        //        new ZagospStatusSlo() { ZagospStatusSloId = 2, Nazwa = "wodociągowa" },
        //        new ZagospStatusSlo() { ZagospStatusSloId = 3, Nazwa = "sanitarna" },
        //        new ZagospStatusSlo() { ZagospStatusSloId = 4, Nazwa = "komercyjna" },
        //        new ZagospStatusSlo() { ZagospStatusSloId = 5, Nazwa = "mieszana" }
        //);

            modelBuilder.Entity<PrzedstawicielSlo>().HasData(
                new PrzedstawicielSlo() { PrzedstawicielSloId = 1, Nazwa = "-" },
                new PrzedstawicielSlo() { PrzedstawicielSloId = 2, Nazwa = "GIWK EE" },
                new PrzedstawicielSlo() { PrzedstawicielSloId = 3, Nazwa = "GIWK TE" },
                new PrzedstawicielSlo() { PrzedstawicielSloId = 4, Nazwa = "GIWK TS" },
                new PrzedstawicielSlo() { PrzedstawicielSloId = 5, Nazwa = "SNG" },
                new PrzedstawicielSlo() { PrzedstawicielSloId = 6, Nazwa = "inny" }
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

            modelBuilder.Entity<ZagospStatusSlo>().HasData(
                new ZagospStatusSlo { ZagospStatusSloId = 1, Nazwa = "Wod/Kan/Energ" },
                new ZagospStatusSlo { ZagospStatusSloId = 2, Nazwa = "Komercyjna" });

            modelBuilder.Entity<ZagospFunkcjaSlo>().HasData(
                new ZagospFunkcjaSlo { ZagospFunkcjaSloId = 1, Nazwa = "wodociągowa" },
                new ZagospFunkcjaSlo { ZagospFunkcjaSloId = 2, Nazwa = "kanlizacyjna" },
                new ZagospFunkcjaSlo { ZagospFunkcjaSloId = 3, Nazwa = "energetyczna" },
                new ZagospFunkcjaSlo { ZagospFunkcjaSloId = 4, Nazwa = "mieszana" },
                new ZagospFunkcjaSlo { ZagospFunkcjaSloId = 5, Nazwa = "społeczna" },
                new ZagospFunkcjaSlo { ZagospFunkcjaSloId = 6, Nazwa = "użytkowa" },
                new ZagospFunkcjaSlo { ZagospFunkcjaSloId = 7, Nazwa = "finansowa" },
                new ZagospFunkcjaSlo { ZagospFunkcjaSloId = 8, Nazwa = "mieszana" });

            modelBuilder.Entity<ZagospStatus>().HasData(
                new ZagospStatus { ZagospStatusId = 1, ZagospStatusSloId = 1, ZagospFunkcjaSloId = 1 },
                new ZagospStatus { ZagospStatusId = 2, ZagospStatusSloId = 1, ZagospFunkcjaSloId = 2 },
                new ZagospStatus { ZagospStatusId = 3, ZagospStatusSloId = 1, ZagospFunkcjaSloId = 3 },
                new ZagospStatus { ZagospStatusId = 4, ZagospStatusSloId = 1, ZagospFunkcjaSloId = 4 },
                new ZagospStatus { ZagospStatusId = 5, ZagospStatusSloId = 2, ZagospFunkcjaSloId = 5 },
                new ZagospStatus { ZagospStatusId = 6, ZagospStatusSloId = 2, ZagospFunkcjaSloId = 6 },
                new ZagospStatus { ZagospStatusId = 7, ZagospStatusSloId = 2, ZagospFunkcjaSloId = 7 },
                new ZagospStatus { ZagospStatusId = 8, ZagospStatusSloId = 2, ZagospFunkcjaSloId = 8 }
                );
        }
    }
}
