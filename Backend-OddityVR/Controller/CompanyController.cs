using Backend_OddityVR.Domain.AppService;
using Backend_OddityVR.Domain.DTO.CompanyDTO;
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
        public CompaniesDetailsDTO CreateNewCompany(CreateCompanyCmd newCompanyCmd)
        {
            try
            {
                return _companyService.CreateNewCompany(newCompanyCmd);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new CompaniesDetailsDTO();
            }
        }


        [Route("get_all")]
        [HttpGet]
        public List<CompaniesDetailsDTO> GetAllCompanies()
        {
            return _companyService.GetAllCompanies();
        }


        [Route("get/{id:int}")]
        [HttpGet]
        public CompaniesDetailsDTO GetCompany(int id)
        {
            return _companyService.GetCompanyById(id);
        }


        [Route("update")]
        [HttpPut]
        public CompaniesDetailsDTO UpdateCompany(Company company)
        {
            return _companyService.UpdateCompany(company);
        }


        [Route("delete/{id:int}")]
        [HttpDelete]
        public void DeleteCompany(int id)
        {
            _companyService.DeleteCompany(id);
        }
    }
}
