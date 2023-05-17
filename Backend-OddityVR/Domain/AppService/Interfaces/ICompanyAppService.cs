using Backend_OddityVR.Domain.DTO.CompanyDTO;

namespace Backend_OddityVR.Domain.AppService
{
    public interface ICompanyAppService
    {
        public CompaniesDetailsDTO CreateNewCompany(CreateCompanyCmd newCompany);
        public List<CompaniesDetailsDTO> GetAllCompanies();
        public CompaniesDetailsDTO GetCompanyById(int id);
        public CompaniesDetailsDTO UpdateCompany(UpdateCompanyCmd company);
        public void DeleteCompany(int id);
    }
}
