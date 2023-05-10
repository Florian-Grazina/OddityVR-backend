using Backend_OddityVR.Domain.DTO;
using Backend_OddityVR.Domain.Repo;

namespace Backend_OddityVR.Domain.AppService
{
    public class DepartmentAppService
    {
        // properties
        private readonly DepartmentRepo _departmentRepo;
        private readonly UserRepo _userRepo;


        // constructor
        public DepartmentAppService()
        {
            _departmentRepo = new();
            _userRepo = new();
        }


        // create
        public void CreateNewDepartment(CreateDepartmentCmd newDepartment)
        {
            Department department = newDepartment.ToModel();
            _departmentRepo.CreateNewDepartment(department);
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
        public void DeleteDepartmentAsync(int id)
        {
            List<User> listUsers = _userRepo.GetAllUser();
            List<User> usersInDepartment = listUsers.Where(user => user.DepartmentId == id).ToList();

            if(usersInDepartment.Count > 0)
            {
                Console.WriteLine("Some users are linked to the department : ");
                usersInDepartment.ForEach(user => Console.WriteLine(user.Id + " " + user.Email));
            }
            else
            {
                _departmentRepo.DeleteDepartment(id);
            }
        }
    }
}
