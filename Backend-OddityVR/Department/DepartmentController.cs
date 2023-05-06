using Backend_OddityVR.Department.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Backend_OddityVR.Department
{
    [Route("api/department")]
    [ApiController]
    public class DepartmentController
    {
        // properties
        private readonly DepartmentAppService _departmentService;


        // constructor
        public DepartmentController(DepartmentAppService departmentService)
        {
            _departmentService = departmentService;
        }


        // methods
        [Route("create")]
        [HttpPost]
        public void CreateNewDepartment(CreateDepartmentCmd newDepartmentCmd)
        {
            _departmentService.CreateNewDepartment(newDepartmentCmd);
        }


        [Route("get_all")]
        [HttpGet]
        public List<Department> GetAllDepartments()
        {
            return _departmentService.GetAllDepartments();
        }


        [Route("get/{id:int}")]
        [HttpGet]
        public Department GetDepartment(int id)
        {
            return _departmentService.GetDepartmentById(id);
        }


        [Route("update/{id:int}")]
        [HttpPost]
        public void UpdateDepartment(CreateDepartmentCmd newDepartmentCmd, int id)
        {
            _departmentService.UpdateDepartment(newDepartmentCmd, id);
        }


        [Route("delete/{id:int}")]
        [HttpGet]
        public void DeleteDepartment(int id)
        {
            _departmentService.DeleteDepartment(id);
        }
    }
}
