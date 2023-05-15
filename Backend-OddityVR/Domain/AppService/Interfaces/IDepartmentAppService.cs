using Backend_OddityVR.Domain.DTO.DepartmentsDTO;

namespace Backend_OddityVR.Domain.AppService
{
    public interface IDepartmentAppService
    {
        public DepartmentDetailsDTO CreateNewDepartment(CreateDepartmentCmd newDepartment);
        public List<Department> GetAllDepartments();
        public Department GetDepartmentById(int id);
        public List<DepartmentDetailsDTO> GetAllDepartmentsWithCompanyId(int id);
        public DepartmentDetailsDTO UpdateDepartment(Department department);
        public void DeleteDepartmentAsync(int id);
    }
}
