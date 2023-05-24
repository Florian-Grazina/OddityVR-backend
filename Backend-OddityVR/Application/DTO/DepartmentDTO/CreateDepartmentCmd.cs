using Backend_OddityVR.Domain.Model;

namespace Backend_OddityVR.Application.DTO.DepartmentDTO
{
    public class CreateDepartmentCmd : ICmdAndDTO
    {
        // properties
        public string Name { get; set; }
        public int CompanyId { get; set; }


        // constructor
        public CreateDepartmentCmd() { }


        // methods
        public IModel ToModel()
        {
            return new Department
            {
                Name = Name,
                CompanyId = CompanyId
            };
        }
    }
}
