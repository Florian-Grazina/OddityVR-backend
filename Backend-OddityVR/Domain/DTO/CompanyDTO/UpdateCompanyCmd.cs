using Backend_OddityVR.Model;

namespace Backend_OddityVR.Domain.DTO.CompanyDTO
{
    public class UpdateCompanyCmd : ICmdAndDTO
    {
        // properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }


        // methods
        public IModel ToModel()
        {
            return new Company
            {
                Id = Id,
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
