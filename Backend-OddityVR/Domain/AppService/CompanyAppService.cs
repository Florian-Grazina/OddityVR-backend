using Backend_OddityVR.Domain.DTO;
using Backend_OddityVR.Domain.Repo;
using System.Reflection;

namespace Backend_OddityVR.Domain.AppService
{
    public class CompanyAppService : ICompanyAppService
    {
        // properties
        private readonly CompanyRepo _companyRepo;


        // constructor
        public CompanyAppService()
        {
            _companyRepo = new();
        }


        // create
        public Company CreateNewCompany(CreateCompanyCmd newCompany)
        {
            PropertyInfo[] properties = newCompany.GetType().GetProperties(); ;

            foreach (PropertyInfo property in properties)
            {
                if (property.GetValue(newCompany).ToString() == "")
                {
                    throw new Exception("The element " + property.ToString() + " of the form is missing");
                }
            }

            Company company = newCompany.ToModel();
            return _companyRepo.CreateNewCompany(company);
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
