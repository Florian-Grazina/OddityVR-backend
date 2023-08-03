using Backend_OddityVR.Application.AppService.Interfaces;
using Backend_OddityVR.Application.DTO;
using Backend_OddityVR.Application.DTO.TestDTO;
using Backend_OddityVR.Domain.Model;
using Backend_OddityVR.Infrastructure.Repo;

namespace Backend_OddityVR.Application.AppService
{
    public class TestResultAppService : ITestResultAppService
    {
        // properties
        private readonly TestResultRepo _testResultRepo;
        private readonly UserRepo _userRepo;
        private readonly DepartmentRepo _departmentRepo;
        private readonly CompanyRepo _companyRepo;
        private readonly RoleRepo _roleRepo;


        // constructor
        public TestResultAppService(TestResultRepo testRepoResult, UserRepo userRepo, DepartmentRepo departmentRepo, CompanyRepo companyRepo, RoleRepo roleRepo)
        {
            _testResultRepo = testRepoResult;
            _userRepo = userRepo;
            _departmentRepo = departmentRepo;
            _companyRepo = companyRepo;
            _roleRepo = roleRepo;
        }


        // create
        public void CreateNewTestResult(CreateTestResultCmd newTestResult)
        {
            TestResult testResult = newTestResult.ToModel();
            _testResultRepo.CreateNewTestResult(testResult);
        }


        // get all
        public List<TestResult> GetAllTestResults()
        {
            return _testResultRepo.GetAllTestResults();
        }

        public List<TestUserDTO> GetAllTestUsers()
        {
            List<User> users = _userRepo.GetUsersWithTest();

            List<TestUserDTO> testUsers = new();
            users.ForEach(user => testUsers.Add(GetTestUserById(user.Id)));

            return testUsers;
        }

        // get id
        public TestResult GetTestResultById(int id)
        {
            return _testResultRepo.GetTestResultById(id);
        }

        public TestUserDTO GetTestUserById(int id)
        {
            User user = _userRepo.GetUserById(id);
            Department department = _departmentRepo.GetDepartmentById(user.DepartmentId);

            return new TestUserDTO()
            {
                Id = user.Id,
                Email = user.Email,
                Role = _roleRepo.GetRoleById(user.RoleId).Name,
                Company = _companyRepo.GetCompanyById(department.CompanyId).Name,
                Department = department.Name
            };
        }


        // update
        public void UpdateTestResult(CreateTestResultCmd updateTestResult, int id)
        {
            TestResult testResult = updateTestResult.ToModel(id);

            _testResultRepo.UpdateTestResult(testResult);
        }


        // delete
        public void DeleteTestResultAsync(int id)
        {
            _testResultRepo.DeleteTestResult(id);
        }
    }
}
