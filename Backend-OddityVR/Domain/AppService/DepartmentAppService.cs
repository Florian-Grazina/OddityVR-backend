using Backend_OddityVR.Domain.DTO.CompanyDTO;
using Backend_OddityVR.Domain.DTO.DepartmentsDTO;
using Backend_OddityVR.Domain.Repo;
using System.Reflection;

namespace Backend_OddityVR.Domain.AppService
{
    public class DepartmentAppService : IDepartmentAppService
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
        public DepartmentDetailsDTO CreateNewDepartment(CreateDepartmentCmd newDepartment)
        {
            PropertyInfo[] properties = newDepartment.GetType().GetProperties(); ;

            foreach (PropertyInfo property in properties)
            {
                if (property.GetValue(newDepartment).ToString() == "")
                {
                    throw new Exception("The element " + property.ToString() + " of the form is missing");
                }
            }

            Department departmentToReturn = _departmentRepo.CreateNewDepartment(newDepartment.ToModel());
            return new DepartmentDetailsDTO(departmentToReturn, 0);
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
        public Department GetDepartmentById(int id)
        {
            return _departmentRepo.GetDepartmentById(id);
        }


        // update
        public DepartmentDetailsDTO UpdateDepartment(Department department)
        {
            _departmentRepo.UpdateDepartment(department);
            int numberOfEmployees = _userRepo.GetAllUserFromDepartmentId(department.Id).Count;
            DepartmentDetailsDTO departmentToReturn = new(department, numberOfEmployees);

            return departmentToReturn;
        }


        // delete
        public void DeleteDepartmentAsync(int id)
        {
            List<User> listUsers = _userRepo.GetAllUser();
            List<User> usersInDepartment = listUsers.Where(user => user.DepartmentId == id).ToList();

            if (usersInDepartment.Count > 0)
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
