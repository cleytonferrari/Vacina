using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Repositorio;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDb;

namespace WebMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connString = Configuration["CONN_STRING"];
            var database = Configuration["CONN_DATABASE"];
            
            services.AddSingleton<IVacinadosRepositorio, VacinadosRepositorio>((provider) =>
            {
                return new VacinadosRepositorio(connString, database);
            });
            services.AddSingleton<IEstatisticaRepositorio, EstatisticaRepositorio>((provider) =>
            {
                return new EstatisticaRepositorio(connString, database);
            });
            services.AddSingleton<IInconsistenciaRepositorio, InconsistenciaRepositorio>((provider) =>
            {
                return new InconsistenciaRepositorio(connString, database);
            });
            services.AddSingleton<IUsuarioRepositorio, UsuarioRepositorio>((provider) =>
            {
                return new UsuarioRepositorio(connString, database);
            });
            services.AddSingleton<IMunicipioRepositorio, MunicipioRepositorio>((provider) =>
            {
                return new MunicipioRepositorio(connString, database);
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.LoginPath = "/login";
                    });
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
