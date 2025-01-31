namespace SolutionUXComex.RegistrationOfPeople.Service.Dtos
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string Cpf { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Complement { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Active { get; set; }

    }
}
