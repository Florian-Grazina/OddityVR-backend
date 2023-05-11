using Backend_OddityVR.Domain.DTO;

namespace Backend_OddityVR.Domain.AppService
{
    public interface IDepartmentAppService
    {
        public void CreateNewDepartment(CreateDepartmentCmd newDepartment);
        public List<Department> GetAllDepartments();
        public Department GetDepartmentById(int id);
        public void UpdateDepartment(CreateDepartmentCmd updateDepartment, int id);
        public void DeleteDepartmentAsync(int id);
    }
}
