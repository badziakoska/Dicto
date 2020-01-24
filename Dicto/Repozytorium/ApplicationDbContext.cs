using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dicto.Models;

namespace Dicto.Repozytorium
{
    /// <summary>
    /// Klasa dziedziczy po klasie DbContext, 
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //właściwość umożliwiająca odczytywanie i zapisywanie danych
        
        public DbSet<Dziennik> Dzienniki { get; set; }
        public DbSet<Grupa> Grupy { get; set; }
        public DbSet<Terapeuta> Terapeuci { get; set; }
        public DbSet<Uczen> Uczniowie { get; set; }
        public DbSet<UczenNaZajeciach> UczniowieNaZajeciach { get; set; }
        public DbSet<Zajecia> WszystkieZajecia { get; set; }
        public DbSet<ZajeciaWPlanie> PlanZajec {get; set; }
    }
}
