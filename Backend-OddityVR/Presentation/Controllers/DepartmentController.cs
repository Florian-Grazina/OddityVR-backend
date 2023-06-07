using Backend_OddityVR.Application.AppService.Interfaces;
using Backend_OddityVR.Application.DTO.DepartmentDTO;
using Backend_OddityVR.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Backend_OddityVR.Presentation.Controllers
{
    [Route("api/department")]
    [EnableCors("Dashboard")]
    //[Authorize]
    [ApiController]
    public class DepartmentController : Controller
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
        public ActionResult<DepartmentDetailsDTO> CreateNewDepartment(CreateDepartmentCmd newDepartmentCmd)
        {
            try
            {
                return Ok(_departmentService.CreateNewDepartment(newDepartmentCmd));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("get_all")]
        [HttpGet]
        public ActionResult<List<Department>> GetAllDepartments()
        {
            try
            {
                return Ok(_departmentService.GetAllDepartments());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("get/{id:int}")]
        [HttpGet]
        public ActionResult<DepartmentDetailsDTO> GetDepartmentById(int id)
        {
            try
            {
                return Ok(_departmentService.GetDepartmentById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("get_all_from_company/{id:int}")]
        [HttpGet]
        public ActionResult<List<DepartmentDetailsDTO>> GetAllDepartmentsWithCompanyId(int id)
        {
            try
            {
                return Ok(_departmentService.GetAllDepartmentsWithCompanyId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("update")]
        [HttpPut]
        public ActionResult<DepartmentDetailsDTO> UpdateDepartment(UpdateDepartmentCmd department)
        {
            try
            {
                return Ok(_departmentService.UpdateDepartment(department));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("delete/{id:int}")]
        [HttpDelete]
        public ActionResult DeleteDepartment(int id)
        {
            try
            {
                _departmentService.DeleteDepartment(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
