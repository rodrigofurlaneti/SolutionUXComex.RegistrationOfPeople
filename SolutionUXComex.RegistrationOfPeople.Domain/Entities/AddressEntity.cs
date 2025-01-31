using Dapper.Contrib.Extensions;
using SolutionUXComex.RegistrationOfPeople.Domain.Attributes;

namespace SolutionUXComex.RegistrationOfPeople.Domain.Entities
{
    [Table("Addresses")] // Mapeia a classe para a tabela "Addresses"
    public class AddressEntity : BaseEntity
    {
        public string ZipCode { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Complement { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
    }
}
