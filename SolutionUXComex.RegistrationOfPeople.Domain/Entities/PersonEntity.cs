using Dapper.Contrib.Extensions;
using SolutionUXComex.RegistrationOfPeople.Domain.Attributes;

namespace SolutionUXComex.RegistrationOfPeople.Domain.Entities
{
    [Table("Persons")] // Mapeia a classe para a tabela "Persons"
    public class PersonEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Complement { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;

    }
}
