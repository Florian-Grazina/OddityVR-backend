using Backend_OddityVR.Application.AppService.Interfaces;
using Backend_OddityVR.Application.DTO.DepartmentDTO;
using Backend_OddityVR.Domain.Model;
using Backend_OddityVR.Domain.Service;
using Backend_OddityVR.Infrastructure.Repo;

namespace Backend_OddityVR.Application.AppService
{
    public class DepartmentAppService : IDepartmentAppService
    {
        // properties
        private readonly DepartmentRepo _departmentRepo;
        private readonly UserRepo _userRepo;


        // constructor
        public DepartmentAppService(DepartmentRepo departmentRepo, UserRepo userRepo)
        {
            _departmentRepo = departmentRepo;
            _userRepo = userRepo;
        }


        // create
        public DepartmentDetailsDTO CreateNewDepartment(CreateDepartmentCmd newDepartment)
        {

            if (CmdFieldsChecker.Check(newDepartment))
            {
                Department departmentToReturn = _departmentRepo.CreateNewDepartment((Department)newDepartment.ToModel());
                return new DepartmentDetailsDTO(departmentToReturn, 0);
            }
            else throw new Exception("Cmd is not complete");
        }


        // get all
        public List<Department> GetAllDepartments()
        {
            return _departmentRepo.GetAllDepartments();
        }

        public List<DepartmentDetailsDTO> GetAllDepartmentsWithCompanyId(int id)
        {
            List<Department> departments = _departmentRepo.GetDepartmentByCompanyId(id);
            List<User> users = _userRepo.GetAllUserFromCompanyId(id);

            List<DepartmentDetailsDTO> departmentsToReturn = new();

            foreach (Department department in departments)
            {
                departmentsToReturn.Add(new DepartmentDetailsDTO(
                    department,
                    users.Where(user => user.DepartmentId == department.Id).ToList().Count)
                    );
            }
            return departmentsToReturn;
        }


        // get id
        public DepartmentDetailsDTO GetDepartmentById(int id)
        {
            Department department = _departmentRepo.GetDepartmentById(id);
            int numberOfEmployees = _userRepo.GetAllUsersFromDepartmentId(id).Count;

            if(department != null)
            {
                return new DepartmentDetailsDTO(department, numberOfEmployees);
            }
            throw new Exception("Department not found");
        }


        // update
        public DepartmentDetailsDTO UpdateDepartment(UpdateDepartmentCmd departmentCmd)
        {
            if (CmdFieldsChecker.Check(departmentCmd))
            {
                if (_departmentRepo.GetDepartmentById(departmentCmd.Id) != null)
                {
                    Department updatedDepartment = (Department)departmentCmd.ToModel();
                    int numberOfEmployees = _userRepo.GetAllUsersFromDepartmentId(updatedDepartment.Id).Count;

                    _departmentRepo.UpdateDepartment(updatedDepartment);
                    return new DepartmentDetailsDTO(updatedDepartment, numberOfEmployees);
                }
                else throw new Exception("Department doesn't exist");
            }
            else throw new Exception("Cmd is not complete");
        }


        // delete
        public void DeleteDepartment(int id)
        {
            if (_departmentRepo.GetDepartmentById(id) != null)
            {
                List<User> listUsers = _userRepo.GetAllUser();
                List<User> usersInDepartment = listUsers.Where(user => user.DepartmentId == id).ToList();

                if (usersInDepartment.Count <= 0)
                {
                    _departmentRepo.DeleteDepartment(id);
                }
                else throw new Exception("Users are assigned to the department");
            }
            else throw new Exception("Department doesn't exist");
        }
    }
}
