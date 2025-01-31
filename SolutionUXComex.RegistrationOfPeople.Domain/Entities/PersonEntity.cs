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
    }
}
