﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RejestrNieruchomosciNew;

namespace RejestrNieruchomosciNew.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20200416095506_dom4")]
    partial class dom4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RejestrNieruchomosciNew.Dzialka", b =>
                {
                    b.Property<int>("DzialkaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdresId");

                    b.Property<string>("Kwakt");

                    b.Property<string>("Kwzrob");

                    b.Property<int?>("NadzorKonserwSloId");

                    b.Property<string>("Numer");

                    b.Property<int>("ObrebId");

                    b.Property<double?>("Pow");

                    b.Property<string>("dostDoDrogi");

                    b.Property<string>("ksztalt");

                    b.Property<string>("lokalizacja");

                    b.Property<string>("rodzNaw");

                    b.Property<string>("sasiedztwo");

                    b.Property<string>("uzbrojenie");

                    b.HasKey("DzialkaId");

                    b.HasIndex("NadzorKonserwSloId");

                    b.HasIndex("ObrebId");

                    b.HasIndex("Numer", "ObrebId")
                        .IsUnique()
                        .HasFilter("[Numer] IS NOT NULL");

                    b.ToTable("Dzialka");
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.FormaWladaniaSlo", b =>
                {
                    b.Property<int>("FormaWladaniaSloId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa");

                    b.HasKey("FormaWladaniaSloId");

                    b.ToTable("FormaWladaniaSlo");

                    b.HasData(
                        new
                        {
                            FormaWladaniaSloId = 1,
                            Nazwa = "-"
                        },
                        new
                        {
                            FormaWladaniaSloId = 2,
                            Nazwa = "Własność"
                        },
                        new
                        {
                            FormaWladaniaSloId = 3,
                            Nazwa = "UW"
                        });
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.GminaSlo", b =>
                {
                    b.Property<int>("GminaSloId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa");

                    b.HasKey("GminaSloId");

                    b.ToTable("GminaSlo");
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Model.Adres", b =>
                {
                    b.Property<int>("AdresId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DzialkaId");

                    b.Property<int>("MiejscowoscSloId");

                    b.Property<string>("Numer");

                    b.Property<int>("UlicaSloId");

                    b.HasKey("AdresId");

                    b.HasIndex("DzialkaId")
                        .IsUnique()
                        .HasFilter("[DzialkaId] IS NOT NULL");

                    b.HasIndex("MiejscowoscSloId");

                    b.HasIndex("UlicaSloId");

                    b.ToTable("Adres");
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Model.Budynek", b =>
                {
                    b.Property<int>("BudynekId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DzialkaId");

                    b.Property<int>("MediaId");

                    b.Property<string>("Nazwa");

                    b.Property<int>("iloscKond");

                    b.Property<double>("kubatura");

                    b.Property<double>("numerEwid");

                    b.Property<double>("powBezPiwnic");

                    b.Property<double>("powCalk");

                    b.Property<double>("powPiwnic");

                    b.Property<double>("powZabud");

                    b.Property<string>("stanTech");

                    b.Property<bool>("wpisRejZab");

                    b.HasKey("BudynekId");

                    b.ToTable("Budynek");
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Model.DecyzjeAdministracyjne", b =>
                {
                    b.Property<int>("DecyzjeAdministracyjneId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataDecyzji");

                    b.Property<string>("Numer");

                    b.Property<int?>("PodmiotId");

                    b.Property<string>("Przedmiot");

                    b.Property<string>("Skan");

                    b.HasKey("DecyzjeAdministracyjneId");

                    b.ToTable("DecyzjeAdministracyjne");
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Model.Dzialka_Budynek", b =>
                {
                    b.Property<int>("DzialkaId");

                    b.Property<int>("BudynekId");

                    b.HasKey("DzialkaId", "BudynekId");

                    b.HasIndex("BudynekId");

                    b.ToTable("Dzialka_Budynek");
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Model.InnePrawa", b =>
                {
                    b.Property<int>("InnePrawaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CelNabyciaId");

                    b.Property<DateTime?>("DataObowDo");

                    b.Property<DateTime?>("DataObowOd");

                    b.Property<int?>("DecyzjeAdministracyjneId");

                    b.Property<int>("DzialkaId");

                    b.Property<int>("PodmiotId");

                    b.Property<DateTime?>("ProtPrzejData");

                    b.Property<string>("ProtPrzejScan");

                    b.Property<string>("ProtPrzejkNr");

                    b.Property<DateTime?>("ProtZwrotData");

                    b.Property<string>("ProtZwrotNr");

                    b.Property<string>("ProtZwrotScan");

                    b.Property<int?>("RodzajInnegoPrawaSloId");

                    b.Property<int?>("TransK_Id");

                    b.Property<int?>("TransS_Id");

                    b.Property<string>("WarunkiRealizacji");

                    b.Property<DateTime?>("wizjaTerPrzek");

                    b.Property<DateTime?>("wizjaTerZwrot");

                    b.HasKey("InnePrawaId");

                    b.HasIndex("DecyzjeAdministracyjneId");

                    b.HasIndex("DzialkaId");

                    b.HasIndex("RodzajInnegoPrawaSloId");

                    b.HasIndex("TransK_Id");

                    b.HasIndex("TransS_Id");

                    b.ToTable("InnePrawa");
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Model.MiejscowoscSlo", b =>
                {
                    b.Property<int>("MiejscowoscSloId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GminaSloId");

                    b.Property<int>("MiejscowoscUlice");

                    b.Property<string>("Nazwa");

                    b.HasKey("MiejscowoscSloId");

                    b.ToTable("MiejscowoscSlo");
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Model.NadzorKonserwSlo", b =>
                {
                    b.Property<int>("NadzorKonserwSloId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa");

                    b.HasKey("NadzorKonserwSloId");

                    b.ToTable("NadzorKonserwSlo");

                    b.HasData(
                        new
                        {
                            NadzorKonserwSloId = 1,
                            Nazwa = "-"
                        },
                        new
                        {
                            NadzorKonserwSloId = 2,
                            Nazwa = "Nie"
                        },
                        new
                        {
                            NadzorKonserwSloId = 3,
                            Nazwa = "Tak"
                        });
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Model.PlatnoscInnePrawa", b =>
                {
                    b.Property<int>("PlatnoscInnePrawaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InnePrawaId");

                    b.Property<int?>("Okres");

                    b.Property<double?>("Stawka");

                    b.Property<double?>("Wartosc");

                    b.Property<double?>("Wysokosc");

                    b.Property<int?>("rok1");

                    b.Property<int?>("rok2");

                    b.Property<int?>("rok3");

                    b.HasKey("PlatnoscInnePrawaId");

                    b.HasIndex("InnePrawaId")
                        .IsUnique();

                    b.ToTable("PlatnoscInnePrawa");
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Model.RodzajDokumentuSlo", b =>
                {
                    b.Property<int>("RodzajDokumentuSloId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa");

                    b.HasKey("RodzajDokumentuSloId");

                    b.ToTable("RodzajDokumentuSlo");

                    b.HasData(
                        new
                        {
                            RodzajDokumentuSloId = 1,
                            Nazwa = "-"
                        },
                        new
                        {
                            RodzajDokumentuSloId = 2,
                            Nazwa = "Akt notarialny"
                        },
                        new
                        {
                            RodzajDokumentuSloId = 3,
                            Nazwa = "Postanowienie sądu"
                        });
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Model.RodzajInnegoPrawaSlo", b =>
                {
                    b.Property<int>("RodzajInnegoPrawaSloId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa");

                    b.HasKey("RodzajInnegoPrawaSloId");

                    b.ToTable("RodzajInnegoPrawaSlo");

                    b.HasData(
                        new
                        {
                            RodzajInnegoPrawaSloId = 1,
                            Nazwa = "-"
                        },
                        new
                        {
                            RodzajInnegoPrawaSloId = 2,
                            Nazwa = "dzierżawa"
                        },
                        new
                        {
                            RodzajInnegoPrawaSloId = 3,
                            Nazwa = "najem"
                        },
                        new
                        {
                            RodzajInnegoPrawaSloId = 4,
                            Nazwa = "użyczenie"
                        },
                        new
                        {
                            RodzajInnegoPrawaSloId = 5,
                            Nazwa = "służebność"
                        },
                        new
                        {
                            RodzajInnegoPrawaSloId = 6,
                            Nazwa = "czasowe zajęcie"
                        },
                        new
                        {
                            RodzajInnegoPrawaSloId = 7,
                            Nazwa = "bezumowne"
                        });
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Model.RodzajTransakcjiSlo", b =>
                {
                    b.Property<int>("RodzajTransakcjiSloId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa");

                    b.HasKey("RodzajTransakcjiSloId");

                    b.ToTable("RodzajTransakcjiSlo");

                    b.HasData(
                        new
                        {
                            RodzajTransakcjiSloId = 1,
                            Nazwa = "-"
                        },
                        new
                        {
                            RodzajTransakcjiSloId = 2,
                            Nazwa = "Kupno"
                        },
                        new
                        {
                            RodzajTransakcjiSloId = 3,
                            Nazwa = "Sprzedaż"
                        });
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Model.Transakcje", b =>
                {
                    b.Property<int?>("TransakcjeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Data");

                    b.Property<int?>("NazwaCzynnosciSloId");

                    b.Property<string>("Numer");

                    b.Property<int?>("RodzajDokumentuSloId");

                    b.Property<int?>("RodzajTransakcjiSloId");

                    b.Property<string>("Tytul");

                    b.Property<DateTime?>("WpisDoKW");

                    b.HasKey("TransakcjeId");

                    b.HasIndex("NazwaCzynnosciSloId");

                    b.HasIndex("RodzajDokumentuSloId");

                    b.HasIndex("RodzajTransakcjiSloId");

                    b.ToTable("Transakcje");
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Model.UlicaSlo", b =>
                {
                    b.Property<int>("UlicaSloId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MiejscowoscUlice");

                    b.Property<string>("Nazwa");

                    b.HasKey("UlicaSloId");

                    b.ToTable("UliceSlo");
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Model.Uzytki", b =>
                {
                    b.Property<int>("UzytkiId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DzialkaId");

                    b.Property<double?>("Pow");

                    b.Property<int>("UzytkiSloId");

                    b.HasKey("UzytkiId");

                    b.HasIndex("DzialkaId");

                    b.HasIndex("UzytkiSloId");

                    b.ToTable("Uzytki");
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Model.UzytkiSlo", b =>
                {
                    b.Property<int>("UzytkiSloId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa");

                    b.HasKey("UzytkiSloId");

                    b.ToTable("UzytkiSlo");

                    b.HasData(
                        new
                        {
                            UzytkiSloId = 1,
                            Nazwa = "-"
                        },
                        new
                        {
                            UzytkiSloId = 2,
                            Nazwa = "R"
                        },
                        new
                        {
                            UzytkiSloId = 3,
                            Nazwa = "S"
                        },
                        new
                        {
                            UzytkiSloId = 4,
                            Nazwa = "Ł"
                        },
                        new
                        {
                            UzytkiSloId = 5,
                            Nazwa = "Ps"
                        },
                        new
                        {
                            UzytkiSloId = 6,
                            Nazwa = "Br"
                        },
                        new
                        {
                            UzytkiSloId = 7,
                            Nazwa = "Wsr"
                        },
                        new
                        {
                            UzytkiSloId = 8,
                            Nazwa = "W"
                        },
                        new
                        {
                            UzytkiSloId = 9,
                            Nazwa = "Lzr"
                        },
                        new
                        {
                            UzytkiSloId = 10,
                            Nazwa = "N"
                        },
                        new
                        {
                            UzytkiSloId = 11,
                            Nazwa = "Ls"
                        },
                        new
                        {
                            UzytkiSloId = 12,
                            Nazwa = "Lz"
                        },
                        new
                        {
                            UzytkiSloId = 13,
                            Nazwa = "B"
                        },
                        new
                        {
                            UzytkiSloId = 14,
                            Nazwa = "Ba"
                        },
                        new
                        {
                            UzytkiSloId = 15,
                            Nazwa = "Bi"
                        },
                        new
                        {
                            UzytkiSloId = 16,
                            Nazwa = "Bp"
                        },
                        new
                        {
                            UzytkiSloId = 17,
                            Nazwa = "Bz"
                        },
                        new
                        {
                            UzytkiSloId = 18,
                            Nazwa = "K"
                        },
                        new
                        {
                            UzytkiSloId = 19,
                            Nazwa = "dr"
                        },
                        new
                        {
                            UzytkiSloId = 20,
                            Nazwa = "Tk"
                        },
                        new
                        {
                            UzytkiSloId = 21,
                            Nazwa = "Ti"
                        },
                        new
                        {
                            UzytkiSloId = 22,
                            Nazwa = "Tp"
                        },
                        new
                        {
                            UzytkiSloId = 23,
                            Nazwa = "E-Ws"
                        },
                        new
                        {
                            UzytkiSloId = 24,
                            Nazwa = "E-Wp"
                        },
                        new
                        {
                            UzytkiSloId = 25,
                            Nazwa = "E-Ls"
                        },
                        new
                        {
                            UzytkiSloId = 26,
                            Nazwa = "E-Lz"
                        },
                        new
                        {
                            UzytkiSloId = 27,
                            Nazwa = "E-N"
                        },
                        new
                        {
                            UzytkiSloId = 28,
                            Nazwa = "E-Ps"
                        },
                        new
                        {
                            UzytkiSloId = 29,
                            Nazwa = "E-R"
                        },
                        new
                        {
                            UzytkiSloId = 30,
                            Nazwa = "E-Ł"
                        },
                        new
                        {
                            UzytkiSloId = 31,
                            Nazwa = "E-Lzr"
                        },
                        new
                        {
                            UzytkiSloId = 32,
                            Nazwa = "E-W"
                        },
                        new
                        {
                            UzytkiSloId = 33,
                            Nazwa = "Wm"
                        },
                        new
                        {
                            UzytkiSloId = 34,
                            Nazwa = "Wp"
                        },
                        new
                        {
                            UzytkiSloId = 35,
                            Nazwa = "Ws"
                        },
                        new
                        {
                            UzytkiSloId = 36,
                            Nazwa = "Tr"
                        });
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Model.Zagosp", b =>
                {
                    b.Property<int>("ZagospId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DzialkaId");

                    b.Property<string>("Nazwa");

                    b.Property<int?>("ZagospFunkcjaSloId");

                    b.Property<int?>("ZagospStatusSloId");

                    b.Property<int?>("celeKomSloId");

                    b.Property<int?>("istObiektySloId");

                    b.Property<int?>("obiektyKomSloId");

                    b.Property<int?>("przedstSloId");

                    b.Property<int?>("zadInwestSloId");

                    b.HasKey("ZagospId");

                    b.HasIndex("DzialkaId");

                    b.HasIndex("ZagospFunkcjaSloId");

                    b.HasIndex("ZagospStatusSloId");

                    b.ToTable("Zagosp");
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Model.ZagospFunkcjaSlo", b =>
                {
                    b.Property<int>("ZagospFunkcjaSloId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa");

                    b.HasKey("ZagospFunkcjaSloId");

                    b.ToTable("ZagospFunkcjaSlo");

                    b.HasData(
                        new
                        {
                            ZagospFunkcjaSloId = 1,
                            Nazwa = "-"
                        },
                        new
                        {
                            ZagospFunkcjaSloId = 2,
                            Nazwa = "społeczna"
                        },
                        new
                        {
                            ZagospFunkcjaSloId = 3,
                            Nazwa = "użytkowa"
                        },
                        new
                        {
                            ZagospFunkcjaSloId = 4,
                            Nazwa = "finansowa"
                        },
                        new
                        {
                            ZagospFunkcjaSloId = 5,
                            Nazwa = "mieszana"
                        });
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Model.ZagospStatusSlo", b =>
                {
                    b.Property<int>("ZagospStatusSloId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa");

                    b.HasKey("ZagospStatusSloId");

                    b.ToTable("ZagospStatusSlo");

                    b.HasData(
                        new
                        {
                            ZagospStatusSloId = 1,
                            Nazwa = "-"
                        },
                        new
                        {
                            ZagospStatusSloId = 2,
                            Nazwa = "wodociągowa"
                        },
                        new
                        {
                            ZagospStatusSloId = 3,
                            Nazwa = "sanitarna"
                        },
                        new
                        {
                            ZagospStatusSloId = 4,
                            Nazwa = "komercyjna"
                        },
                        new
                        {
                            ZagospStatusSloId = 5,
                            Nazwa = "mieszana"
                        });
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.NazwaCzynnosciSlo", b =>
                {
                    b.Property<int>("NazwaCzynnosciSloId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa");

                    b.HasKey("NazwaCzynnosciSloId");

                    b.ToTable("NazwaCzynnosciSlo");

                    b.HasData(
                        new
                        {
                            NazwaCzynnosciSloId = 1,
                            Nazwa = "-"
                        },
                        new
                        {
                            NazwaCzynnosciSloId = 2,
                            Nazwa = "Zakup"
                        },
                        new
                        {
                            NazwaCzynnosciSloId = 3,
                            Nazwa = "Aport"
                        });
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Obreb", b =>
                {
                    b.Property<int>("ObrebId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GminaSloId");

                    b.Property<string>("Nazwa");

                    b.Property<string>("Numer");

                    b.HasKey("ObrebId");

                    b.HasIndex("GminaSloId");

                    b.ToTable("Obreb");
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.PlatnoscUW", b =>
                {
                    b.Property<int>("PlatnoscUWId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DzialkaId");

                    b.Property<int?>("Okres");

                    b.Property<double?>("Stawka");

                    b.Property<double?>("Wartosc");

                    b.Property<double?>("Wysokosc");

                    b.Property<int?>("rok1");

                    b.Property<int?>("rok2");

                    b.Property<int?>("rok3");

                    b.HasKey("PlatnoscUWId");

                    b.HasIndex("DzialkaId")
                        .IsUnique();

                    b.ToTable("PlatnoscUW");
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Wladanie", b =>
                {
                    b.Property<int>("WladanieId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CelNabyciaId");

                    b.Property<DateTime?>("DataOdbDo");

                    b.Property<DateTime?>("DataOdbOd");

                    b.Property<DateTime?>("DataProtPrzej");

                    b.Property<int?>("DzialkaId");

                    b.Property<int?>("FormaWladaniaSloId");

                    b.Property<string>("NrProtPrzejecia");

                    b.Property<int?>("PodmiotId");

                    b.Property<string>("Scan");

                    b.Property<int?>("TransK_Id");

                    b.Property<int?>("TransS_Id");

                    b.Property<string>("Udzial");

                    b.HasKey("WladanieId");

                    b.HasIndex("DzialkaId");

                    b.HasIndex("FormaWladaniaSloId");

                    b.HasIndex("TransK_Id");

                    b.HasIndex("TransS_Id");

                    b.ToTable("Wladanie");
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Dzialka", b =>
                {
                    b.HasOne("RejestrNieruchomosciNew.Model.NadzorKonserwSlo", "NadzorKonserwSlo")
                        .WithMany("Dzialka")
                        .HasForeignKey("NadzorKonserwSloId");

                    b.HasOne("RejestrNieruchomosciNew.Obreb", "Obreb")
                        .WithMany("Dzialka")
                        .HasForeignKey("ObrebId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Model.Adres", b =>
                {
                    b.HasOne("RejestrNieruchomosciNew.Dzialka", "Dzialka")
                        .WithOne("Adres")
                        .HasForeignKey("RejestrNieruchomosciNew.Model.Adres", "DzialkaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RejestrNieruchomosciNew.Model.MiejscowoscSlo", "MiejscowoscSlo")
                        .WithMany("Adres")
                        .HasForeignKey("MiejscowoscSloId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RejestrNieruchomosciNew.Model.UlicaSlo", "UlicaSlo")
                        .WithMany("Adres")
                        .HasForeignKey("UlicaSloId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Model.Dzialka_Budynek", b =>
                {
                    b.HasOne("RejestrNieruchomosciNew.Model.Budynek", "Budynek")
                        .WithMany("Dzialka_Budynek")
                        .HasForeignKey("BudynekId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RejestrNieruchomosciNew.Dzialka", "Dzialka")
                        .WithMany("Dzialka_Budynek")
                        .HasForeignKey("DzialkaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Model.InnePrawa", b =>
                {
                    b.HasOne("RejestrNieruchomosciNew.Model.DecyzjeAdministracyjne", "DecyzjeAdministracyjne")
                        .WithMany("InnePrawa")
                        .HasForeignKey("DecyzjeAdministracyjneId");

                    b.HasOne("RejestrNieruchomosciNew.Dzialka", "Dzialka")
                        .WithMany("InnePrawa")
                        .HasForeignKey("DzialkaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RejestrNieruchomosciNew.Model.RodzajInnegoPrawaSlo", "RodzajInnegoPrawaSlo")
                        .WithMany("InnePrawa")
                        .HasForeignKey("RodzajInnegoPrawaSloId");

                    b.HasOne("RejestrNieruchomosciNew.Model.Transakcje", "TransakcjeK_InnePr")
                        .WithMany()
                        .HasForeignKey("TransK_Id");

                    b.HasOne("RejestrNieruchomosciNew.Model.Transakcje", "TransakcjeS_InnePr")
                        .WithMany()
                        .HasForeignKey("TransS_Id");
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Model.PlatnoscInnePrawa", b =>
                {
                    b.HasOne("RejestrNieruchomosciNew.Model.InnePrawa", "InnePrawa")
                        .WithOne("PlatnoscInnePrawa")
                        .HasForeignKey("RejestrNieruchomosciNew.Model.PlatnoscInnePrawa", "InnePrawaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Model.Transakcje", b =>
                {
                    b.HasOne("RejestrNieruchomosciNew.NazwaCzynnosciSlo")
                        .WithMany("Transakcje")
                        .HasForeignKey("NazwaCzynnosciSloId");

                    b.HasOne("RejestrNieruchomosciNew.Model.RodzajDokumentuSlo")
                        .WithMany("Transakcje")
                        .HasForeignKey("RodzajDokumentuSloId");

                    b.HasOne("RejestrNieruchomosciNew.Model.RodzajTransakcjiSlo")
                        .WithMany("Transakcje")
                        .HasForeignKey("RodzajTransakcjiSloId");
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Model.Uzytki", b =>
                {
                    b.HasOne("RejestrNieruchomosciNew.Dzialka", "Dzialka")
                        .WithMany("Uzytki")
                        .HasForeignKey("DzialkaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RejestrNieruchomosciNew.Model.UzytkiSlo", "UzytkiSlo")
                        .WithMany()
                        .HasForeignKey("UzytkiSloId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Model.Zagosp", b =>
                {
                    b.HasOne("RejestrNieruchomosciNew.Dzialka", "Dzialka")
                        .WithMany("Zagosp")
                        .HasForeignKey("DzialkaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RejestrNieruchomosciNew.Model.ZagospFunkcjaSlo", "ZagospFunkcjaSlo")
                        .WithMany("Zagosp")
                        .HasForeignKey("ZagospFunkcjaSloId");

                    b.HasOne("RejestrNieruchomosciNew.Model.ZagospStatusSlo", "ZagospStatusSlo")
                        .WithMany("Zagosp")
                        .HasForeignKey("ZagospStatusSloId");
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Obreb", b =>
                {
                    b.HasOne("RejestrNieruchomosciNew.GminaSlo", "GminaSlo")
                        .WithMany()
                        .HasForeignKey("GminaSloId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.PlatnoscUW", b =>
                {
                    b.HasOne("RejestrNieruchomosciNew.Dzialka", "Dzialka")
                        .WithOne("PlatnoscUW")
                        .HasForeignKey("RejestrNieruchomosciNew.PlatnoscUW", "DzialkaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Wladanie", b =>
                {
                    b.HasOne("RejestrNieruchomosciNew.Dzialka", "Dzialka")
                        .WithMany("Wladanie")
                        .HasForeignKey("DzialkaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RejestrNieruchomosciNew.FormaWladaniaSlo", "FormaWladaniaSlo")
                        .WithMany("Wladanie")
                        .HasForeignKey("FormaWladaniaSloId");

                    b.HasOne("RejestrNieruchomosciNew.Model.Transakcje", "TransakcjeK_Wlad")
                        .WithMany("TransakcjeK_Wlad")
                        .HasForeignKey("TransK_Id");

                    b.HasOne("RejestrNieruchomosciNew.Model.Transakcje", "TransakcjeS_Wlad")
                        .WithMany("TransakcjeS_Wlad")
                        .HasForeignKey("TransS_Id");
                });
#pragma warning restore 612, 618
        }
    }
}
