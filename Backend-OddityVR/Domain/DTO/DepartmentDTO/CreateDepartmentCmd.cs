using Backend_OddityVR.Model;

namespace Backend_OddityVR.Domain.DTO.DepartmentsDTO
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
