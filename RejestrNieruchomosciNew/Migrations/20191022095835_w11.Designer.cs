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
    [Migration("20191022095835_w11")]
    partial class w11
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

                    b.Property<string>("Kwakt");

                    b.Property<string>("Kwzrob");

                    b.Property<string>("Numer");

                    b.Property<int>("ObrebId");

                    b.Property<decimal?>("Pow");

                    b.HasKey("DzialkaId");

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

                    b.HasData(
                        new
                        {
                            GminaSloId = 1,
                            Nazwa = "miasto Gdańsk"
                        },
                        new
                        {
                            GminaSloId = 2,
                            Nazwa = "miasto Sopot"
                        },
                        new
                        {
                            GminaSloId = 3,
                            Nazwa = "miasto Pruszcz Gdański"
                        },
                        new
                        {
                            GminaSloId = 4,
                            Nazwa = "gmina Gdańsk"
                        },
                        new
                        {
                            GminaSloId = 5,
                            Nazwa = "gmina Pruszcz Gdański"
                        },
                        new
                        {
                            GminaSloId = 6,
                            Nazwa = "gmina Żukowo"
                        },
                        new
                        {
                            GminaSloId = 7,
                            Nazwa = "gmina Kolbudy"
                        });
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Model.NabyciePrawa", b =>
                {
                    b.Property<int>("NabyciePrawaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ObowiazywanieDo");

                    b.Property<DateTime>("ObowiazywanieOd");

                    b.Property<string>("ProtokolPrzejecia");

                    b.Property<int>("Skan");

                    b.HasKey("NabyciePrawaId");

                    b.ToTable("NabyciePrawa");
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
                    b.Property<int>("TransakcjeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data");

                    b.Property<int?>("NazwaCzynnosciSloId");

                    b.Property<string>("Numer");

                    b.Property<int>("RodzajCzynnosciId");

                    b.Property<int>("RodzajDokumentuId");

                    b.Property<int?>("RodzajDokumentuSloId");

                    b.Property<int>("RodzajTransakcjiId");

                    b.Property<int?>("RodzajTransakcjiSloId");

                    b.Property<string>("Skan");

                    b.Property<string>("Tytul");

                    b.HasKey("TransakcjeId");

                    b.HasIndex("NazwaCzynnosciSloId");

                    b.HasIndex("RodzajDokumentuSloId");

                    b.HasIndex("RodzajTransakcjiSloId");

                    b.ToTable("Transakcje");
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

                    b.HasKey("ObrebId");

                    b.HasIndex("GminaSloId");

                    b.ToTable("Obreb");

                    b.HasData(
                        new
                        {
                            ObrebId = 1,
                            GminaSloId = 1,
                            Nazwa = "010"
                        },
                        new
                        {
                            ObrebId = 2,
                            GminaSloId = 1,
                            Nazwa = "020"
                        },
                        new
                        {
                            ObrebId = 3,
                            GminaSloId = 1,
                            Nazwa = "030"
                        },
                        new
                        {
                            ObrebId = 4,
                            GminaSloId = 1,
                            Nazwa = "040"
                        },
                        new
                        {
                            ObrebId = 5,
                            GminaSloId = 1,
                            Nazwa = "050"
                        },
                        new
                        {
                            ObrebId = 6,
                            GminaSloId = 1,
                            Nazwa = "060"
                        },
                        new
                        {
                            ObrebId = 7,
                            GminaSloId = 1,
                            Nazwa = "070"
                        },
                        new
                        {
                            ObrebId = 8,
                            GminaSloId = 1,
                            Nazwa = "080"
                        },
                        new
                        {
                            ObrebId = 9,
                            GminaSloId = 1,
                            Nazwa = "090"
                        },
                        new
                        {
                            ObrebId = 10,
                            GminaSloId = 1,
                            Nazwa = "100"
                        },
                        new
                        {
                            ObrebId = 11,
                            GminaSloId = 1,
                            Nazwa = "110"
                        },
                        new
                        {
                            ObrebId = 12,
                            GminaSloId = 1,
                            Nazwa = "120"
                        },
                        new
                        {
                            ObrebId = 13,
                            GminaSloId = 1,
                            Nazwa = "130"
                        },
                        new
                        {
                            ObrebId = 14,
                            GminaSloId = 2,
                            Nazwa = "010"
                        },
                        new
                        {
                            ObrebId = 15,
                            GminaSloId = 2,
                            Nazwa = "020"
                        },
                        new
                        {
                            ObrebId = 16,
                            GminaSloId = 2,
                            Nazwa = "030"
                        },
                        new
                        {
                            ObrebId = 17,
                            GminaSloId = 2,
                            Nazwa = "040"
                        },
                        new
                        {
                            ObrebId = 18,
                            GminaSloId = 2,
                            Nazwa = "050"
                        },
                        new
                        {
                            ObrebId = 19,
                            GminaSloId = 2,
                            Nazwa = "060"
                        },
                        new
                        {
                            ObrebId = 20,
                            GminaSloId = 2,
                            Nazwa = "070"
                        },
                        new
                        {
                            ObrebId = 21,
                            GminaSloId = 3,
                            Nazwa = "010"
                        },
                        new
                        {
                            ObrebId = 22,
                            GminaSloId = 3,
                            Nazwa = "020"
                        },
                        new
                        {
                            ObrebId = 23,
                            GminaSloId = 4,
                            Nazwa = "030"
                        },
                        new
                        {
                            ObrebId = 24,
                            GminaSloId = 4,
                            Nazwa = "040"
                        },
                        new
                        {
                            ObrebId = 25,
                            GminaSloId = 4,
                            Nazwa = "050"
                        });
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.PlatnoscUW", b =>
                {
                    b.Property<int>("PlatnoscUWId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DzialkaId");

                    b.Property<int?>("Okres");

                    b.Property<double?>("Stawka");

                    b.Property<double?>("Wartosc");

                    b.Property<int>("rok1");

                    b.Property<int>("rok2");

                    b.Property<int>("rok3");

                    b.HasKey("PlatnoscUWId");

                    b.HasIndex("DzialkaId")
                        .IsUnique()
                        .HasFilter("[DzialkaId] IS NOT NULL");

                    b.ToTable("PlatnoscUW");
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Podmiot", b =>
                {
                    b.Property<int>("PodmiotId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("Email");

                    b.Property<string>("Fax");

                    b.Property<string>("House");

                    b.Property<string>("Kontakt");

                    b.Property<string>("MobilePhone");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("PostCode");

                    b.Property<string>("Street");

                    b.Property<string>("TaxNumber");

                    b.Property<string>("URL");

                    b.HasKey("PodmiotId");

                    b.ToTable("Podmiot");
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Wladanie", b =>
                {
                    b.Property<int>("WladanieId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DzialkaId");

                    b.Property<int?>("FormaWladaniaSloId");

                    b.Property<int?>("NabycieId");

                    b.Property<int?>("NabyciePrawaId");

                    b.Property<int?>("PodmiodId");

                    b.Property<int?>("PodmiotId");

                    b.Property<int?>("TransakcjaId");

                    b.Property<int?>("TransakcjeId");

                    b.Property<string>("Udzial");

                    b.HasKey("WladanieId");

                    b.HasIndex("DzialkaId");

                    b.HasIndex("FormaWladaniaSloId");

                    b.HasIndex("NabyciePrawaId");

                    b.HasIndex("PodmiotId");

                    b.HasIndex("TransakcjeId");

                    b.ToTable("Wladanie");
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Dzialka", b =>
                {
                    b.HasOne("RejestrNieruchomosciNew.Obreb", "Obreb")
                        .WithMany("Dzialka")
                        .HasForeignKey("ObrebId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Model.Transakcje", b =>
                {
                    b.HasOne("RejestrNieruchomosciNew.NazwaCzynnosciSlo")
                        .WithMany("TransakcjeSlo")
                        .HasForeignKey("NazwaCzynnosciSloId");

                    b.HasOne("RejestrNieruchomosciNew.Model.RodzajDokumentuSlo")
                        .WithMany("TransakcjeSlo")
                        .HasForeignKey("RodzajDokumentuSloId");

                    b.HasOne("RejestrNieruchomosciNew.Model.RodzajTransakcjiSlo")
                        .WithMany("TransakcjeSlo")
                        .HasForeignKey("RodzajTransakcjiSloId");
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
                        .HasForeignKey("RejestrNieruchomosciNew.PlatnoscUW", "DzialkaId");
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Wladanie", b =>
                {
                    b.HasOne("RejestrNieruchomosciNew.Dzialka")
                        .WithMany("Wladanie")
                        .HasForeignKey("DzialkaId");

                    b.HasOne("RejestrNieruchomosciNew.FormaWladaniaSlo")
                        .WithMany("Wladanie")
                        .HasForeignKey("FormaWladaniaSloId");

                    b.HasOne("RejestrNieruchomosciNew.Model.NabyciePrawa")
                        .WithMany("Wladanie")
                        .HasForeignKey("NabyciePrawaId");

                    b.HasOne("RejestrNieruchomosciNew.Podmiot", "Podmiot")
                        .WithMany("Wladanie")
                        .HasForeignKey("PodmiotId");

                    b.HasOne("RejestrNieruchomosciNew.Model.Transakcje")
                        .WithMany("Wladanie")
                        .HasForeignKey("TransakcjeId");
                });
#pragma warning restore 612, 618
        }
    }
}
