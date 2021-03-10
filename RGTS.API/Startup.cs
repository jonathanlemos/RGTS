using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Dominio.Serviços;
using Infra.CrossCutting.Settings;
using Infra.Data.Repositorios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RGTS.API.Config;
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

            services.Configure<MySettings>(Configuration.GetSection("MySettings"));

            var mySettings = Configuration
                .GetSection("MySettings")
                .Get<MySettings>();

            // Config Swagger
            services.AddMySwagger(mySettings.Swagger);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptions<MySettings> mySettingsOpt)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // Configurando CORS
            //app.UseCors(c =>
            //{
            //    c.AllowAnyHeader();
            //    c.AllowAnyMethod();
            //    c.AllowAnyOrigin();
            //});

            // Configurando acesso estático ao arquivo de log (após gravar log no banco remover)
            // https://github.com/aspnet/AspNetCore/blob/507a765dfb078f446c445318e7b55ad9f7f5cbe0/src/Middleware/StaticFiles/src/StaticFileMiddleware.cs
            //app.UseStaticFiles();

            app.UseSwagger();
            
            _ = app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

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
        }

        private void AdicinarInjecaoDeDependenciaRepositorio(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IPerfilRepositorio, PerfilRepositorio>();
            services.AddScoped<IPermissaoRepositorio, PermissaoRepositorio>();
        }
    }
}
