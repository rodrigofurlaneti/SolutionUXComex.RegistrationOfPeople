using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SolutionUXComex.RegistrationOfPeople.Infra;
using Microsoft.Extensions.Configuration;

namespace SolutionUXComex.RegistrationOfPeople.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            // Registrar IDbConnection para Dapper
            services.AddScoped<IDbConnection>(sp => new Microsoft.Data.SqlClient.SqlConnection(connectionString));

            // Registrar inicializador do banco de dados para aplicar migrations
            services.AddScoped<DatabaseInitializer>();

            services.AddLogging(); // Garante que o Logger será resolvido pelos repositórios

            SolutionUXComex.RegistrationOfPeople.Api.DependencyInjection.DependencyInjection.RegisterServices(services);
            services.ConfigureSwagger();

            // Configuração do CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader());
            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SolutionUXComex API v1"));
            }

            // Aplica a política de CORS antes do roteamento
            app.UseCors("AllowAll");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.ConfigureExceptionHandling(env); // Configuração de exceções e Swagger


            // Executar Migrations no startup
            //using (var scope = serviceProvider.CreateScope())
            //{
            //    var dbInitializer = scope.ServiceProvider.GetRequiredService<DatabaseInitializer>();
            //    dbInitializer.ApplyMigrationsAsync().Wait();
            //}
        }
    }
}