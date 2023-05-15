namespace Backend_OddityVR.Domain.DTO.DepartmentsDTO
{
    public class CreateDepartmentCmd
    {
        // properties
        public string Name { get; set; }
        public int CompanyId { get; set; }


        // constructor
        public CreateDepartmentCmd() { }


        // methods
        public Department ToModel(int id = 0)
        {
            return new Department
            {
                Id = id,
                Name = Name,
                CompanyId = CompanyId
            };
        }
    }
}
