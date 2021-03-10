
namespace RGTS.API.Config
{
    using Infra.CrossCutting.Settings;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    public static class SwaggerConfig
    {
        public static IServiceCollection AddMySwagger(this IServiceCollection services, SwaggerSettings settings)
        {
            return services
                .AddSwaggerGen();
        }

        public static IApplicationBuilder AddMySwagger(this IApplicationBuilder app, SwaggerSettings settings)
        {
            app.UseSwagger();

            var versions = settings.Versions;

            _ = app.UseSwaggerUI(c =>
              {
                  c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
              });

            return app;
        }
    }
}
