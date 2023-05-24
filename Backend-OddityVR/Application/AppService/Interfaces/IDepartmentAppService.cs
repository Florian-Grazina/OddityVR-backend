using Backend_OddityVR.Application.DTO.DepartmentDTO;
using Backend_OddityVR.Domain.Model;

namespace Backend_OddityVR.Application.AppService.Interfaces
{
    public interface IDepartmentAppService
    {
        public DepartmentDetailsDTO CreateNewDepartment(CreateDepartmentCmd newDepartment);
        public List<Department> GetAllDepartments();
        public DepartmentDetailsDTO GetDepartmentById(int id);
        public List<DepartmentDetailsDTO> GetAllDepartmentsWithCompanyId(int id);
        public DepartmentDetailsDTO UpdateDepartment(UpdateDepartmentCmd department);
        public void DeleteDepartment(int id);
    }
}
