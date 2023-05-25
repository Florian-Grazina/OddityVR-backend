using Backend_OddityVR.Application.AppService.Interfaces;
using Backend_OddityVR.Application.DTO.CompanyDTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Backend_OddityVR.Presentation.Controllers
{
    [Route("api/company")]
    [EnableCors]
    [ApiController]
    public class CompanyController : Controller
    {
        // properties
        private readonly ICompanyAppService _companyService;


        // constructor
        public CompanyController(ICompanyAppService companyService)
        {
            _companyService = companyService;
        }


        // methods
        [Route("create")]
        [HttpPost]
        public ActionResult<CompanyDetailsDTO> CreateNewCompany(CreateCompanyCmd newCompanyCmd)
        {
            try
            {
                return Ok(_companyService.CreateNewCompany(newCompanyCmd));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //[Authorize]
        [Route("get_all")]
        [HttpGet]
        public ActionResult<List<CompanyDetailsDTO>> GetAllCompanies()
        {
            try
            {
                return Ok(_companyService.GetAllCompanies());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("get/{id:int}")]
        [HttpGet]
        public ActionResult<CompanyDetailsDTO> GetCompany(int id)
        {
            try
            {
                return Ok(_companyService.GetCompanyById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("update")]
        [HttpPut]
        public ActionResult<CompanyDetailsDTO> UpdateCompany(UpdateCompanyCmd company)
        {
            try
            {
                return Ok(_companyService.UpdateCompany(company));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("delete/{id:int}")]
        [HttpDelete]
        public ActionResult DeleteCompany(int id)
        {
            try
            {
                _companyService.DeleteCompany(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
