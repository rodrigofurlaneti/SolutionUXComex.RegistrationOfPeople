using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.IO; // Necessário para Path.Combine

namespace SolutionUXComex.RegistrationOfPeople.Api
{
    public static class StartupExtensions
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                try
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SolutionUXComex API", Version = "v1" });

                    var xmlPath = Path.Combine(AppContext.BaseDirectory, "API.xml");
                    c.IncludeXmlComments(xmlPath);
                    Console.WriteLine($"Swagger XML carregado: {xmlPath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao configurar Swagger: {ex.Message}");
                }
            });
        }

        public static void ConfigureExceptionHandling(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SolutionUXComex API V1");
                });
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
