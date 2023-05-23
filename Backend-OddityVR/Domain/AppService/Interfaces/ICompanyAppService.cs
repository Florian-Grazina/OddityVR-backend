using Backend_OddityVR.Domain.DTO.CompanyDTO;

namespace Backend_OddityVR.Domain.AppService
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
