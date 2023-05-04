using System.ComponentModel.DataAnnotations;

namespace Backend_OddityVR.Company.DTO
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
        public Company ToModel()
        {
            return new Company
            {
                Name = this.Name,
                Number = this.Number,
                Street = this.Street,
                City = this.City,
                PostalCode = this.PostalCode,
                Country = this.Country,
            };
        }

        public Company ToModel(int id)
        {
            return new Company
            {
                Id = id,
                Name = this.Name,
                Number = this.Number,
                Street = this.Street,
                City = this.City,
                PostalCode = this.PostalCode,
                Country = this.Country,
            };
        }
    }
}
