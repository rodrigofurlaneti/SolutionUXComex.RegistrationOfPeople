namespace SolutionUXComex.RegistrationOfPeople.Domain.Entities
{
    public class PersonEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
    }
}
