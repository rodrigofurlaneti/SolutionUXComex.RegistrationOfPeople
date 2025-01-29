using SolutionUXComex.RegistrationOfPeople.Domain.Interfaces;
using SolutionUXComex.RegistrationOfPeople.Infra.Repositories;

namespace SolutionUXComex.RegistrationOfPeople.Api.DependencyInjection
{
    public static class DependencyInjectionRepositories
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // Registro de repositórios genéricos
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            // Registro de repositórios específicos
            services.AddScoped<IPersonRepository, PersonRepository>();

            return services;
        }
    }
}
