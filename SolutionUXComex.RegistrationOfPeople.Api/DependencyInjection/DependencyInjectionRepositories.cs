using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using SolutionUXComex.RegistrationOfPeople.Domain.Interfaces;
using SolutionUXComex.RegistrationOfPeople.Infra.Repositories;

namespace SolutionUXComex.RegistrationOfPeople.Api.DependencyInjection
{
    public static class DependencyInjectionRepositories
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // Registro da conexão com o banco de dados para Dapper
            services.AddScoped<IDbConnection>(sp =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                return new SqlConnection(connectionString); // Namespace: Microsoft.Data.SqlClient
            });

            // Registro de repositórios genéricos
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            // Registro de repositórios específicos
            services.AddScoped<IPersonRepository, PersonRepository>();

            return services;
        }
    }
}
