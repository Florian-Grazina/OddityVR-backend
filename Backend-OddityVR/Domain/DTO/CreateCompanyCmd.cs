using System.ComponentModel.DataAnnotations;

namespace Backend_OddityVR.Domain.DTO
{
    public class CreateCompanyCmd
    {
        // properties
        [Required(ErrorMessage = "Company name is mandatory")]
        public string Name { get; set; }
        public string Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }


        // constructor
        public CreateCompanyCmd() { }


        // methods
        public Company ToModel(int id = 0)
        {
            return new Company
            {
                Id = id,
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
