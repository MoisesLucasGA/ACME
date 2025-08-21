
using ACME.Core.Enums;

namespace ACME.Core.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public required string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public required string CPF { get; set; }
        public SexEnum Sex { get; set; }
        public PatientStatusEnum Status { get; set; }
        public required string ZipCode { get; set; }
        public required string City { get; set; }
        public required string Neighborhood { get; set; }
        public required string Street { get; set; }
        public required string Number { get; set; }
        public string? Complement { get; set; }

    }
}
