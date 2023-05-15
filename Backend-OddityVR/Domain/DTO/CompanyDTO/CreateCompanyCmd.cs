namespace Backend_OddityVR.Domain.DTO.CompanyDTO
{
    public class CreateCompanyCmd
    {
        // properties
        public string Name { get; set; }
        public string Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }


        // constructor
        public CreateCompanyCmd() { }


        // methods
        public Company ToModel()
        {
            return new Company
            {
                Name = Name,
                Number = Number,
                Street = Street,
                City = City,
                PostalCode = PostalCode,
                Country = Country,
            };
        }
    }
}
