using Backend_OddityVR.Domain.AppService;
using Backend_OddityVR.Domain.DTO.DepartmentsDTO;
using Microsoft.AspNetCore.Mvc;

namespace Backend_OddityVR.Controllers
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
        public DepartmentDetailsDTO CreateNewDepartment(CreateDepartmentCmd newDepartmentCmd)
        {
            return _departmentService.CreateNewDepartment(newDepartmentCmd);
        }


        [Route("get_all")]
        [HttpGet]
        public List<Department> GetAllDepartments()
        {
            return _departmentService.GetAllDepartments();
        }


        [Route("get/{id:int}")]
        [HttpGet]
        public DepartmentDetailsDTO GetDepartmentById(int id)
        {
            return _departmentService.GetDepartmentById(id);
        }


        [Route("get_all_from_company/{id:int}")]
        [HttpGet]
        public List<DepartmentDetailsDTO> GetAllDepartmentsWithCompanyId(int id)
        {
            return _departmentService.GetAllDepartmentsWithCompanyId(id);
        }


        [Route("update")]
        [HttpPut]
        public DepartmentDetailsDTO UpdateDepartment(UpdateDepartmentCmd department)
        {
            return _departmentService.UpdateDepartment(department);
        }


        [Route("delete/{id:int}")]
        [HttpDelete]
        public void DeleteDepartment(int id)
        {
            _departmentService.DeleteDepartment(id);
        }
    }
}
