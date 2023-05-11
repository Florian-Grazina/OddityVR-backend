using Backend_OddityVR.Domain.DTO;

namespace Backend_OddityVR.Domain.AppService
{
    public interface ICompanyAppService
    {
        public Company CreateNewCompany(CreateCompanyCmd newCompany);
        public List<Company> GetAllCompanies();
        public Company GetCompanyById(int id);
        public void UpdateCompany(CreateCompanyCmd updateCompanyCmd, int id);
        public void DeleteCompany(int id);
    }
}
