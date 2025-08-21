namespace ACME.Core.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public required string ZipCode { get; set; }
        public required string City { get; set; }
        public required string Neighborhood { get; set; }
        public required string Street { get; set; }
        public required string Number { get; set; }
        public string? Complement { get; set; }

    }
}
