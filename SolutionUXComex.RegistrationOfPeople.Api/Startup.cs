using Microsoft.EntityFrameworkCore;
using SolutionUXComex.RegistrationOfPeople.Infra.Data;

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
            services.AddDbContext<UXComexAppDbContext>(options =>
                options.UseSqlServer(connectionString));

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

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SolutionUXComex RegistrationOfPeople API v1"));
            }

            // Aplica a política de CORS antes do roteamento - Ambiente de DEV
            app.UseCors("AllowAll");

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}