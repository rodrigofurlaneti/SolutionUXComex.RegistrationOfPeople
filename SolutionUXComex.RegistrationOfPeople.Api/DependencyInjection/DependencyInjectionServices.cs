using SolutionUXComex.RegistrationOfPeople.Service.Interfaces;
using SolutionUXComex.RegistrationOfPeople.Service.Services;

namespace SolutionUXComex.RegistrationOfPeople.Api.DependencyInjection
{
    public static class DependencyInjectionServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Registro de serviços específicos
            services.AddScoped<IPersonService, PersonService>();

            return services;
        }
    }
}
