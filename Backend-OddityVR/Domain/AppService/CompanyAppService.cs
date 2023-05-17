using Backend_OddityVR.Domain.DTO.CompanyDTO;
using Backend_OddityVR.Domain.Repo;
using Backend_OddityVR.Service;

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
            if (CmdFieldsChecker.Check(newCompany))
            {
                Company companytoReturn = _companyRepo.CreateNewCompany((Company)newCompany.ToModel());
                return new CompaniesDetailsDTO(companytoReturn, 0);
            }
            else throw new Exception("Cmd is not complete");
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

            if (company != null)
            {
                CompaniesDetailsDTO companyToReturn = new(company, departments.Where(dep => dep.CompanyId == id).ToList().Count);
                return companyToReturn;
            }
            throw new Exception("Company not found");
        }


        // update
        public CompaniesDetailsDTO UpdateCompany(UpdateCompanyCmd companyCmd)
        {
            if (CmdFieldsChecker.Check(companyCmd))
            {
                if (_companyRepo.GetCompanyById(companyCmd.Id) != null)
                {
                    Company updatedCompany = (Company) companyCmd.ToModel();
                    int numberOfDepartments = _departmentRepo.GetDepartmentByCompanyId(companyCmd.Id).Count;

                    _companyRepo.UpdateCompany(updatedCompany);
                    return new CompaniesDetailsDTO (updatedCompany, numberOfDepartments);
                }
                else throw new Exception("Company doesn't exist");
            }
            else throw new Exception("Cmd is not complete");
        }


        // delete
        public void DeleteCompany(int id)
        {
            if (_companyRepo.GetCompanyById(id) != null)
            {
                _companyRepo.DeleteCompany(id);
            }
            else
                throw new Exception("Company doesn't exist");
        }
    }
}
