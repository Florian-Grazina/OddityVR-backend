using Backend_OddityVR.Company.DTO;

namespace Backend_OddityVR.Company
{
    public class CompanyAppService
    {
        // properties
        private readonly CompanyRepo _companyRepo;


        // constructor
        public CompanyAppService()
        {
            _companyRepo = new();
        }


        // create
        public void CreateNewCompany(CreateCompanyCmd newCompany)
        {
            Company company = newCompany.ToModel();
            _companyRepo.CreateNewCompany(company);
        }


        // get all
        public List<Company> GetAllCompanies()
        {
            return _companyRepo.GetAllCompanies();
        }


        // get id
        public Company GetCompanyById(int id)
        {
            return _companyRepo.GetCompanyById(id);
        }


        // update
        public void UpdateCompany(CreateCompanyCmd updateCompanyCmd, int id)
        {
            Company company = updateCompanyCmd.ToModel(id);
            _companyRepo.UpdateCompany(company);
        }


        // delete
        public void DeleteCompany(int id)
        {
            _companyRepo.DeleteCompany(id);
        }
    }
}
