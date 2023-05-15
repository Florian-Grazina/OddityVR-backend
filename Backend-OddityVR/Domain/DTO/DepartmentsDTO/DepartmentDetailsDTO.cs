namespace Backend_OddityVR.Domain.DTO.DepartmentsDTO
{
    public class DepartmentDetailsDTO
    {
        // properties
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfEmployees { get; set; }


        // constructor
        public DepartmentDetailsDTO() { }


        public DepartmentDetailsDTO(Department department, int numberOfEmployees)
        {
            Id = department.Id;
            Name = department.Name;
            NumberOfEmployees = numberOfEmployees;
        }
    }
}
