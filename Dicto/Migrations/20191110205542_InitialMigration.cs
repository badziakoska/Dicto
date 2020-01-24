using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dicto.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dzienniki",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Nazwa = table.Column<string>(nullable: true),
                    Rok = table.Column<int>(nullable: false),
                    IdTerapeuty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dzienniki", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grupy",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Nazwa = table.Column<string>(nullable: true),
                    PlanPracy = table.Column<string>(nullable: true),
                    IdDziennika = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanZajec",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DzienTygodnia = table.Column<int>(nullable: false),
                    GodzinaRozpoczecia = table.Column<DateTime>(nullable: false),
                    GodzinaZakonczenia = table.Column<DateTime>(nullable: false),
                    IdDziennika = table.Column<int>(nullable: false),
                    IdGrupy = table.Column<int>(nullable: false),
                    IdUcznia = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanZajec", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Terapeuci",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Imie = table.Column<string>(nullable: true),
                    Nazwisko = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Haslo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terapeuci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uczniowie",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Imie = table.Column<string>(nullable: true),
                    Nazwisko = table.Column<string>(nullable: true),
                    IdGrupy = table.Column<int>(nullable: false),
                    IdDziennika = table.Column<int>(nullable: false),
                    Diagnoza = table.Column<int>(nullable: false),
                    OpisWady = table.Column<string>(nullable: true),
                    PlanPracy = table.Column<string>(nullable: true),
                    Uwagi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uczniowie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UczniowieNaZajeciach",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IdUcznia = table.Column<int>(nullable: false),
                    IdZajec = table.Column<int>(nullable: false),
                    Obecnosc = table.Column<bool>(nullable: false),
                    PostepUcznia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UczniowieNaZajeciach", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WszystkieZajecia",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IdZajecZPlanu = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Temat = table.Column<string>(nullable: true),
                    Scenariusz = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WszystkieZajecia", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dzienniki");

            migrationBuilder.DropTable(
                name: "Grupy");

            migrationBuilder.DropTable(
                name: "PlanZajec");

            migrationBuilder.DropTable(
                name: "Terapeuci");

            migrationBuilder.DropTable(
                name: "Uczniowie");

            migrationBuilder.DropTable(
                name: "UczniowieNaZajeciach");

            migrationBuilder.DropTable(
                name: "WszystkieZajecia");
        }
    }
}
