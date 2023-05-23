namespace Backend_OddityVR.Domain.DTO.CompanyDTO
{
    public class CompanyDetailsDTO
    {
        // properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public int NumberOfDepartments { get; set; }


        // constructor
        public CompanyDetailsDTO() { }

        public CompanyDetailsDTO(Company company, int numberOfDepartments)
        {
            Id = company.Id;
            Name = company.Name;
            Number = company.Number;
            Street = company.Street;
            City = company.City;
            PostalCode = company.PostalCode;
            Country = company.Country;
            NumberOfDepartments = numberOfDepartments;
        }
    }
}
