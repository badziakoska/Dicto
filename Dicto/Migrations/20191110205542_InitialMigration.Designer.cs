﻿// <auto-generated />
using System;
using Dicto.Repozytorium;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dicto.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191110205542_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dicto.Models.Dziennik", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdTerapeuty");

                    b.Property<string>("Nazwa");

                    b.Property<int>("Rok");

                    b.HasKey("Id");

                    b.ToTable("Dzienniki");
                });

            modelBuilder.Entity("Dicto.Models.Grupa", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdDziennika");

                    b.Property<string>("Nazwa");

                    b.Property<string>("PlanPracy");

                    b.HasKey("Id");

                    b.ToTable("Grupy");
                });

            modelBuilder.Entity("Dicto.Models.Terapeuta", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Haslo");

                    b.Property<string>("Imie");

                    b.Property<string>("Nazwisko");

                    b.HasKey("Id");

                    b.ToTable("Terapeuci");
                });

            modelBuilder.Entity("Dicto.Models.Uczen", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Diagnoza");

                    b.Property<int>("IdDziennika");

                    b.Property<int>("IdGrupy");

                    b.Property<string>("Imie");

                    b.Property<string>("Nazwisko");

                    b.Property<string>("OpisWady");

                    b.Property<string>("PlanPracy");

                    b.Property<string>("Uwagi");

                    b.HasKey("Id");

                    b.ToTable("Uczniowie");
                });

            modelBuilder.Entity("Dicto.Models.UczenNaZajeciach", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdUcznia");

                    b.Property<int>("IdZajec");

                    b.Property<bool>("Obecnosc");

                    b.Property<string>("PostepUcznia");

                    b.HasKey("Id");

                    b.ToTable("UczniowieNaZajeciach");
                });

            modelBuilder.Entity("Dicto.Models.Zajecia", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data");

                    b.Property<int>("IdZajecZPlanu");

                    b.Property<string>("Scenariusz");

                    b.Property<string>("Temat");

                    b.HasKey("Id");

                    b.ToTable("WszystkieZajecia");
                });

            modelBuilder.Entity("Dicto.Models.ZajeciaWPlanie", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DzienTygodnia");

                    b.Property<DateTime>("GodzinaRozpoczecia");

                    b.Property<DateTime>("GodzinaZakonczenia");

                    b.Property<int>("IdDziennika");

                    b.Property<int>("IdGrupy");

                    b.Property<int>("IdUcznia");

                    b.HasKey("Id");

                    b.ToTable("PlanZajec");
                });
#pragma warning restore 612, 618
        }
    }
}
