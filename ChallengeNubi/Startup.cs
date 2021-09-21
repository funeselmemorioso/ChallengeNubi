using ChallengeNubi.Business.MELI;
using ChallengeNubi.Business.MELI.Interfaces;
using ChallengeNubi.Business.Usuarios;
using ChallengeNubi.Business.Usuarios.Interfaces;
using ChallengeNubi.Common.Utils;
using ChallengeNubi.DA.Contexts;
using ChallengeNubi.DA.Repositories;
using ChallengeNubi.Services.MELI;
using ChallengeNubi.Services.MELI.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ChallengeNubi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }       
       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ChallengeNubi", Version = "1.0" });                
            });        

            var DbContext = Configuration.GetConnectionString("DbContext");
            services.AddDbContext<IChallengeNubiDbContext, ChallengeNubiDbContext>(a => a.UseSqlServer(DbContext));

            services.AddTransient<IPaisesBusiness, PaisesBusiness>();
            services.AddTransient<IPaisesService, PaisesService>();
            services.AddTransient<IUsuariosBusiness, UsuariosBusiness>();
            services.AddTransient<IUsuariosRepository, UsuariosRepository>();
            services.AddTransient<ICurrenciesService, CurrenciesService>();
            services.AddTransient<ICurrenciesBusiness, CurrenciesBusiness>();
            services.AddTransient<IArchivosHandler, ArchivosHandler>();
            services.AddTransient<IBusquedasBusiness, BusquedasBusiness>();
            services.AddTransient<IBusquedasService, BusquedasService>();

            services.AddControllers(); 
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BasicAuth v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
