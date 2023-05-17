using Backend_OddityVR.Model;

namespace Backend_OddityVR.Domain.DTO.DepartmentsDTO
{
    public class UpdateDepartmentCmd : ICmdAndDTO
    {
        // properties
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }


        // constructor
        public UpdateDepartmentCmd() { }


        // methods
        public IModel ToModel()
        {
            return new Department
            {
                Id = Id,
                Name = Name,
                CompanyId = CompanyId
            };
        }
    }
}
