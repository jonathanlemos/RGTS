using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Dominio.Autenticacao;
using Dominio.Servicos;
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
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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
            //jwt autenticacao
            services.AddCors();
            var key = Encoding.ASCII.GetBytes(AutenticacaoConfig.chave);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


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

            app.UseCors(i => i.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AdicinarInjecaoDeDependenciaServico(IServiceCollection services)
        {
            services.AddScoped(typeof(IServicoBase<>), typeof(ServicoBase<>));
            services.AddScoped<IPessoaServico, PessoaServico>();
            services.AddScoped<IPerfilServico, PerfilServico>();
            services.AddScoped<IPermissaoServico, PermissaoServico>();
            services.AddScoped<IEstadoServico, EstadoServico>();
            services.AddScoped<ICidadeServico, CidadeServico>();
            services.AddScoped<IItensNdServico, ItensNdServico>();
            services.AddScoped<IRubricaServico, RubricaServico>();
            services.AddScoped<ILucServico, LucServico>();
            services.AddScoped<IContratoLucServico, ContratoLucServico>();
            services.AddScoped<IContratoLocacaoServico, ContratoLocacaoServico>();
            services.AddScoped<IValoresFaturadoServico, ValoresFaturadoServico>();
            services.AddScoped<IMarcaServico, MarcaServico>();
            services.AddScoped<ILoginPessoaServico, LoginPessoaServico>();
        }

        private void AdicinarInjecaoDeDependenciaRepositorio(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            services.AddScoped<IPessoaRepositorio, PessoaRepositorio>();
            services.AddScoped<IPerfilRepositorio, PerfilRepositorio>();
            services.AddScoped<IPermissaoRepositorio, PermissaoRepositorio>();
            services.AddScoped<IEstadoRepositorio, EstadoRepositorio>();
            services.AddScoped<ICidadeRepositorio, CidadeRepositorio>();
            services.AddScoped<IItensNdRepositorio, ItensNdRepositorio>();
            services.AddScoped<IRubricaRepositorio, RubricaRepositorio>();
            services.AddScoped<ILucRepositorio, LucRepositorio>();
            services.AddScoped<IContratoLocacaoRepositorio, ContratoLocacaoRepositorio>();
            services.AddScoped<IContratoLucRepositorio, ContratoLucRepositorio>();
            services.AddScoped<IValoresFaturadoRepositorio, ValoresFaturadoRepositorio>();
            services.AddScoped<ISexoRepositorio, SexoRepositorio>();
            services.AddScoped<IMarcaRepositorio, MarcaRepositorio>();
            services.AddScoped<ILoginPessoaRepositorio, LoginPessoaRepositorio>();
        }
    }
}
