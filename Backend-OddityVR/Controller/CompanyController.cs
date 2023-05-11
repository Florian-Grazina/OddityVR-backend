using Backend_OddityVR.Domain.AppService;
using Backend_OddityVR.Domain.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Backend_OddityVR.Controller
{
    [Route("api/company")]
    [EnableCors]
    [ApiController]
    public class CompanyController
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
        public Company CreateNewCompany(CreateCompanyCmd newCompanyCmd)
        {
            try
            {
                return _companyService.CreateNewCompany(newCompanyCmd);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Company();
            }
        }


        [Route("get_all")]
        [HttpGet]
        public List<Company> GetAllCompanies()
        {
            return _companyService.GetAllCompanies();
        }


        [Route("get/{id:int}")]
        [HttpGet]
        public Company GetCompany(int id)
        {
            return _companyService.GetCompanyById(id);
        }


        [Route("update/{id:int}")]
        [HttpPut]
        public void UpdateCompany(CreateCompanyCmd newCompanyCmd, int id)
        {
            _companyService.UpdateCompany(newCompanyCmd, id);
        }


        [Route("delete/{id:int}")]
        [HttpDelete]
        public void DeleteCompany(int id)
        {
            _companyService.DeleteCompany(id);
        }
    }
}
