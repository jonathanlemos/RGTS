using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Dominio.Serviços;
using Infra.Data.Repositorios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RGTS.API
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
            services.AddControllers();

            AdicinarInjecaoDeDependenciaServico(services);

            AdicinarInjecaoDeDependenciaRepositorio(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseCors(i => i.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        
        private void AdicinarInjecaoDeDependenciaServico(IServiceCollection services)
        {
            services.AddScoped(typeof(IServicoBase<>), typeof(ServicoBase<>));
            services.AddScoped<IUsuarioServico, UsuarioServico>();
            services.AddScoped<IPerfilServico, PerfilServico>();
            services.AddScoped<IPermissaoServico, PermissaoServico>();
            services.AddScoped<IEstadoServico, EstadoServico>();
            services.AddScoped<IMunicipioServico, MunicipioServico>();
            services.AddScoped<IItensNdServico, ItensNdServico>();
        }

        private void AdicinarInjecaoDeDependenciaRepositorio(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IPerfilRepositorio, PerfilRepositorio>();
            services.AddScoped<IPermissaoRepositorio, PermissaoRepositorio>();
            services.AddScoped<IEstadoRepositorio, EstadoRepositorio>();
            services.AddScoped<IMunicipioRepositorio, MunicipioRepositorio>();
            services.AddScoped<IItensNdRepositorio, ItensNdRepositorio>();
        }
    }
}
