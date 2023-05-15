using Backend_OddityVR.Domain.DTO.CompanyDTO;
using Backend_OddityVR.Domain.DTO.DepartmentsDTO;
using Backend_OddityVR.Domain.Repo;
using System.Reflection;

namespace Backend_OddityVR.Domain.AppService
{
    public class CompanyAppService : ICompanyAppService
    {
        // properties
        private readonly CompanyRepo _companyRepo;
        private readonly DepartmentRepo _departmentRepo;
        private readonly UserRepo _userRepo;


        // constructor
        public CompanyAppService(CompanyRepo companyRepo, DepartmentRepo departmentRepo, UserRepo userRepo)
        {
            _companyRepo = companyRepo;
            _departmentRepo = departmentRepo;
            _userRepo = userRepo;
        }


        // create
        public CompaniesDetailsDTO CreateNewCompany(CreateCompanyCmd newCompany)
        {
            PropertyInfo[] properties = newCompany.GetType().GetProperties(); ;

            foreach (PropertyInfo property in properties)
            {
                if (property.GetValue(newCompany).ToString() == "")
                {
                    throw new Exception("The element " + property.ToString() + " of the form is missing");
                }
            }

            Company companytoReturn = _companyRepo.CreateNewCompany(newCompany.ToModel());
            return new CompaniesDetailsDTO(companytoReturn, 0);
        }


        // get all
        public List<CompaniesDetailsDTO> GetAllCompanies()
        {
            List<Company> companies = _companyRepo.GetAllCompanies();
            List<Department> departments = _departmentRepo.GetAllDepartments();
            List<CompaniesDetailsDTO> toReturn = new ();

            foreach (Company company in companies)
            {
                int numberOfDepartments = departments.Where(dep => dep.CompanyId == company.Id).ToList().Count;

                toReturn.Add(new CompaniesDetailsDTO(company, numberOfDepartments));
            }
            return toReturn;
        }


        // get id
        public CompaniesDetailsDTO GetCompanyById(int id)
        {
            Company company = _companyRepo.GetCompanyById(id);
            List<Department> departments = _departmentRepo.GetDepartmentByCompanyId(id);

            CompaniesDetailsDTO companyToReturn = new(company, departments.Where(dep => dep.CompanyId == id).ToList().Count);

            return companyToReturn;
        }


        // update
        public CompaniesDetailsDTO UpdateCompany(Company company)
        {
            _companyRepo.UpdateCompany(company);
            int numberOfDepartments = _departmentRepo.GetDepartmentByCompanyId(company.Id).Count;
            CompaniesDetailsDTO companyToReturn = new(company, numberOfDepartments);

            return companyToReturn;
        }


        // delete
        public void DeleteCompany(int id)
        {
            _companyRepo.DeleteCompany(id);
        }
    }
}
