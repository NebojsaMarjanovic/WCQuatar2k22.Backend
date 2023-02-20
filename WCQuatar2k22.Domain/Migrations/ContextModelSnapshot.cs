﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WCQuatar2k22.Domain.Domain;

#nullable disable

namespace WCQuatar2k22.Domain.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WCQuatar2k22.Domain.Models.Drzava", b =>
                {
                    b.Property<int>("DrzavaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DrzavaId"));

                    b.Property<int>("BrojDatihGolova")
                        .HasColumnType("int");

                    b.Property<int>("BrojIzgubljenih")
                        .HasColumnType("int");

                    b.Property<int>("BrojNeresenih")
                        .HasColumnType("int");

                    b.Property<int>("BrojOdigranihMeceva")
                        .HasColumnType("int");

                    b.Property<int>("BrojPobeda")
                        .HasColumnType("int");

                    b.Property<int>("BrojPrimljenihGolova")
                        .HasColumnType("int");

                    b.Property<int?>("GrupaId")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OsvojeniPoeni")
                        .HasColumnType("int");

                    b.Property<int>("Sesir")
                        .HasColumnType("int");

                    b.Property<string>("Zastava")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DrzavaId");

                    b.HasIndex("GrupaId");

                    b.ToTable("Drzava");
                });

            modelBuilder.Entity("WCQuatar2k22.Domain.Models.Grupa", b =>
                {
                    b.Property<int>("GrupaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GrupaId"));

                    b.Property<bool>("JeZakljucana")
                        .HasColumnType("bit");

                    b.Property<string>("NazivGrupe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GrupaId");

                    b.ToTable("Grupa");
                });

            modelBuilder.Entity("WCQuatar2k22.Domain.Models.Stadion", b =>
                {
                    b.Property<int>("StadionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StadionId"));

                    b.Property<int>("Kapacitet")
                        .HasColumnType("int");

                    b.Property<string>("Lokacija")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NazivStadiona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slika")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StadionId");

                    b.ToTable("Stadion");
                });

            modelBuilder.Entity("WCQuatar2k22.Domain.Models.Utakmica", b =>
                {
                    b.Property<int>("UtakmicaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UtakmicaId"));

                    b.Property<int>("DomacinId")
                        .HasColumnType("int");

                    b.Property<int?>("DomacinRezultat")
                        .HasColumnType("int");

                    b.Property<int>("GostId")
                        .HasColumnType("int");

                    b.Property<int?>("GostRezultat")
                        .HasColumnType("int");

                    b.Property<int>("StadionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("VremeOdrzavanja")
                        .HasColumnType("datetime2");

                    b.HasKey("UtakmicaId");

                    b.HasIndex("DomacinId");

                    b.HasIndex("GostId");

                    b.HasIndex("StadionId");

                    b.ToTable("Utakmica");
                });

            modelBuilder.Entity("WCQuatar2k22.Domain.Models.Drzava", b =>
                {
                    b.HasOne("WCQuatar2k22.Domain.Models.Grupa", "Grupa")
                        .WithMany("Drzave")
                        .HasForeignKey("GrupaId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Grupa");
                });

            modelBuilder.Entity("WCQuatar2k22.Domain.Models.Utakmica", b =>
                {
                    b.HasOne("WCQuatar2k22.Domain.Models.Drzava", "Domacin")
                        .WithMany()
                        .HasForeignKey("DomacinId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WCQuatar2k22.Domain.Models.Drzava", "Gost")
                        .WithMany()
                        .HasForeignKey("GostId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WCQuatar2k22.Domain.Models.Stadion", "Stadion")
                        .WithMany()
                        .HasForeignKey("StadionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Domacin");

                    b.Navigation("Gost");

                    b.Navigation("Stadion");
                });

            modelBuilder.Entity("WCQuatar2k22.Domain.Models.Grupa", b =>
                {
                    b.Navigation("Drzave");
                });
#pragma warning restore 612, 618
        }
    }
}
