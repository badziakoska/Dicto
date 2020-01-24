using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Dicto.Repozytorium;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Dicto.Models;

namespace Dicto
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["Data:DictoDB:ConnectionStrings:Default"]));//dodanie kontekstu DB
            services.AddTransient<IRepository<Dziennik>, SQLRepository<Dziennik>>();//implementacja interfejsu IRepository<Dziennik> jest w klasie SQLRepository<Dziennik>
            services.AddTransient<IRepository<Grupa>, SQLRepository<Grupa>>();
            services.AddTransient<IRepository<Terapeuta>, SQLRepository<Terapeuta>>();
            services.AddTransient<IRepository<Uczen>, SQLRepository<Uczen>>();
            services.AddTransient<IRepository<UczenNaZajeciach>, SQLRepository<UczenNaZajeciach>>();
            services.AddTransient<IRepository<Zajecia>, SQLRepository<Zajecia>>();
            services.AddTransient<IRepository<ZajeciaWPlanie>, SQLRepository<ZajeciaWPlanie>>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage(); //tej metody nie powinno być w wersji produkcyjnej
            app.UseStatusCodePages(); //udziela odpowiedzi o stanie wyświetlanej strony
            app.UseStaticFiles(); // włącza obsługę treści statycznej z katalogu wwwroot
            //zdefiniowanie routingu
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: default,
                    template: "{controller=Dziennik}/{action=Index}/{id?}");

            });
        }
    }
}
