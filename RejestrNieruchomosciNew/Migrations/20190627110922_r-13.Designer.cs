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
    [Migration("20190627110922_r-13")]
    partial class r13
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

            modelBuilder.Entity("RejestrNieruchomosciNew.Dzialka", b =>
                {
                    b.HasOne("RejestrNieruchomosciNew.Obreb", "Obreb")
                        .WithMany("Dzialka")
                        .HasForeignKey("ObrebId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RejestrNieruchomosciNew.Obreb", b =>
                {
                    b.HasOne("RejestrNieruchomosciNew.GminaSlo", "GminaSlo")
                        .WithMany("Obreb")
                        .HasForeignKey("GminaSloId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}