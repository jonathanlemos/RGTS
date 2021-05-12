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

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

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
            services.AddScoped<IRubricaServico, RubricaServico>();
            services.AddScoped<ITipoInstrumentoServico, TipoInstrumentoServico>();
            services.AddScoped<IMarcaServico, MarcaServico>();
            services.AddScoped<ILucServico, LucServico>();
            services.AddScoped<IValoresFaturadosServico, ValoresFaturadosServico>();
            services.AddScoped<IContratoLucsServico, ContratoLucsServico>();
            services.AddScoped<IContratoLocacaoServico, ContratoLocacaoServico>();
            services.AddScoped<IPessoaPapelInstrumentoServico, PessoaPapelInstrumentoServico>();
            services.AddScoped<INdServico, NdServico>();
            services.AddScoped<IItensNdServico, ItensNdServico>();
            services.AddScoped<INdServico, NdServico>();
            services.AddScoped<IInstrucaoBoletoServico, InstrucaoBoletoServico>();
            services.AddScoped<IMensagemBoletoServico, MensagemBoletoServico>();
            services.AddScoped<IPessoaServico, PessoaServico>();
            services.AddScoped<IPartilhaBancariaServico, PartilhaBancariaServico>();
            services.AddScoped<IServicoCobrancaServico, ServicoCobrancaServico>();
            services.AddScoped<IItensNdPartilhadosServico, ItensNdPartilhadosServico>();
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
            services.AddScoped<IRubricaRepositorio, RubricaRepositorio>();
            services.AddScoped<ITipoInstrumentoRepositorio, TipoInstrumentoRepositorio>();
            services.AddScoped<IMarcaRepositorio, MarcaRepositorio>();
            services.AddScoped<ILucRepositorio, LucRepositorio>();
            services.AddScoped<IValoresFaturadosRepositorio, ValoresFaturadosRepositorio>();
            services.AddScoped<IContratoLucsRepositorio, ContratoLucsRepositorio>();
            services.AddScoped<IContratoLocacaoRepositorio, ContratoLocacaoRepositorio>();
            services.AddScoped<IPessoaPapelInstrumentoRepositorio, PessoaPapelInstrumentoRepositorio>();
            services.AddScoped<INdRepositorio, NdRepositorio>();
            services.AddScoped<IItensNdRepositorio, ItensNdRepositorio>();
            services.AddScoped<INdRepositorio, NdRepositorio>();
            services.AddScoped<IInstrucaoBoletoRepositorio, InstrucaoBoletoRepositorio>();
            services.AddScoped<IMensagemBoletoRepositorio, MensagemBoletoRepositorio>();
            services.AddScoped<IPessoaRepositorio, PessoaRepositorio>();
            services.AddScoped<IPartilhaBancariaRepositorio, PartilhaBancariaRepositorio>();
            services.AddScoped<IServicoCobrancaRepositorio, ServicoCobrancaRepositorio>();
            services.AddScoped<IItensNdPartilhadosRepositorio, ItensNdPartilhadosRepositorio>();
        }
    }
}
