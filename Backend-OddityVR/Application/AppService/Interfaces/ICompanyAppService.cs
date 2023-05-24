using Backend_OddityVR.Application.DTO.CompanyDTO;

namespace Backend_OddityVR.Application.AppService.Interfaces
{
    public interface ICompanyAppService
    {
        public CompanyDetailsDTO CreateNewCompany(CreateCompanyCmd newCompany);
        public List<CompanyDetailsDTO> GetAllCompanies();
        public CompanyDetailsDTO GetCompanyById(int id);
        public CompanyDetailsDTO UpdateCompany(UpdateCompanyCmd company);
        public void DeleteCompany(int id);
    }
}
