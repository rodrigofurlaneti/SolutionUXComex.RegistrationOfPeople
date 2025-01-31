using Microsoft.Extensions.DependencyInjection;
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
            services.AddScoped<IAddressService, AddressService>();

            return services;
        }
    }
}
