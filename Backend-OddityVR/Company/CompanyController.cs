using Backend_OddityVR.Company.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace Backend_OddityVR.Company
{
    [Route("api/company")]
    [ApiController]
    public class CompanyController
    {
        // properties
        private readonly CompanyAppService _companyService;


        // constructor
        public CompanyController(CompanyAppService companyService)
        {
            _companyService = companyService;
        }


        // methods
        [Route("create")]
        [HttpPost]
        public void CreateNewCompany(CreateCompanyCmd newCompanyCmd)
        {
            _companyService.CreateNewCompany(newCompanyCmd);
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
        [HttpPost]
        public void UpdateCompany(CreateCompanyCmd newCompanyCmd, int id)
        {
            _companyService.UpdateCompany(newCompanyCmd, id);
        }


        [Route("delete/{id:int}")]
        [HttpGet]
        public void DeleteCompany(int id)
        {
            _companyService.DeleteCompany(id);
        }
    }
}
