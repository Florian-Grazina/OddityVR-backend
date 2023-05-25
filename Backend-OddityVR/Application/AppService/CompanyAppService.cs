using Backend_OddityVR.Application.AppService.Interfaces;
using Backend_OddityVR.Application.DTO.CompanyDTO;
using Backend_OddityVR.Domain.Model;
using Backend_OddityVR.Domain.Service;
using Backend_OddityVR.Infrastructure.Repo;

namespace Backend_OddityVR.Application.AppService
{
    public class CompanyAppService : ICompanyAppService
    {
        // properties
        private readonly CompanyRepo _companyRepo;
        private readonly DepartmentRepo _departmentRepo;


        // constructor
        public CompanyAppService(CompanyRepo companyRepo, DepartmentRepo departmentRepo, UserRepo userRepo)
        {
            _companyRepo = companyRepo;
            _departmentRepo = departmentRepo;
        }


        // create
        public CompanyDetailsDTO CreateNewCompany(CreateCompanyCmd newCompany)
        {
            if (CmdFieldsChecker.Check(newCompany))
            {
                Company companytoReturn = _companyRepo.CreateNewCompany((Company)newCompany.ToModel());
                return new CompanyDetailsDTO(companytoReturn, 0);
            }
            else throw new Exception("Cmd is not complete");
        }


        // get all
        public List<CompanyDetailsDTO> GetAllCompanies()
        {
            List<Company> companies = _companyRepo.GetAllCompanies();
            List<Department> departments = _departmentRepo.GetAllDepartments();
            List<CompanyDetailsDTO> companiesToReturn = new();

            foreach (Company company in companies)
            {
                int numberOfDepartments = departments.Where(dep => dep.CompanyId == company.Id).ToList().Count;

                companiesToReturn.Add(new CompanyDetailsDTO(company, numberOfDepartments));
            }
            return companiesToReturn;
        }


        // get id
        public CompanyDetailsDTO GetCompanyById(int id)
        {
            Company company = _companyRepo.GetCompanyById(id);
            List<Department> departments = _departmentRepo.GetDepartmentByCompanyId(id);

            if (company != null)
            {
                int numberOfDepartments = departments.Where(dep => dep.CompanyId == id).ToList().Count;
                return new CompanyDetailsDTO(company, numberOfDepartments);
            }
            throw new Exception("Company not found");
        }


        // update
        public CompanyDetailsDTO UpdateCompany(UpdateCompanyCmd companyCmd)
        {
            if (CmdFieldsChecker.Check(companyCmd))
            {
                if (_companyRepo.GetCompanyById(companyCmd.Id) != null)
                {
                    Company updatedCompany = (Company)companyCmd.ToModel();
                    int numberOfDepartments = _departmentRepo.GetDepartmentByCompanyId(companyCmd.Id).Count;

                    _companyRepo.UpdateCompany(updatedCompany);
                    return new CompanyDetailsDTO(updatedCompany, numberOfDepartments);
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
                List<Department> listDepartments = _departmentRepo.GetAllDepartments();
                List<Department> departmentsInCompany = listDepartments.Where(dep => dep.CompanyId == id).ToList();

                if (departmentsInCompany.Count <= 0)
                {
                    _companyRepo.DeleteCompany(id);
                }
                else throw new Exception("Departments are assigned to the company");
            }
            else throw new Exception("Department doesn't exist");
        }
    }
}
