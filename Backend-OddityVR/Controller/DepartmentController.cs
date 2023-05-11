using Backend_OddityVR.Domain.AppService;
using Backend_OddityVR.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Backend_OddityVR.Controller
{
    [Route("api/department")]
    [ApiController]
    public class DepartmentController
    {
        // properties
        private readonly IDepartmentAppService _departmentService;


        // constructor
        public DepartmentController(IDepartmentAppService departmentService)
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
        public Department GetDepartmentById(int id)
        {
            return _departmentService.GetDepartmentById(id);
        }


        [Route("update/{id:int}")]
        [HttpPut]
        public void UpdateDepartment(CreateDepartmentCmd updateDepartmentCmd, int id)
        {
            _departmentService.UpdateDepartment(updateDepartmentCmd, id);
        }


        [Route("delete/{id:int}")]
        [HttpDelete]
        public void DeleteDepartment(int id)
        {
            _departmentService.DeleteDepartmentAsync(id);
        }
    }
}
