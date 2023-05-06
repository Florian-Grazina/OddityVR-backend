using Backend_OddityVR.Department.DTO;

namespace Backend_OddityVR.Department
{
    public class DepartmentAppService
    {
        // properties
        private readonly DepartmentRepo _departmentRepo;


        // construcgtor
        public DepartmentAppService (DepartmentRepo departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }


        // create
        public void CreateNewDepartment(CreateDepartmentCmd newDepartment)
        {
            Department department = newDepartment.ToModel();
            _departmentRepo.CreateDepartement(department);
        }


        // get all
        public List<Department> GetAllDepartments()
        {
            return _departmentRepo.GetAllDepartments();
        }


        // get id
        public Department GetDepartmentById(int id)
        {
            return _departmentRepo.GetDepartmentById(id);
        }


        // update
        public void UpdateDepartment(CreateDepartmentCmd updateDepartment, int id)
        {
            Department department = updateDepartment.ToModel(id);
            _departmentRepo.UpdateDepartment(department);
        }


        // delete
        public void DeleteDepartment(int id)
        {
            _departmentRepo.DeleteDepartment(id);
        }
    }
}
