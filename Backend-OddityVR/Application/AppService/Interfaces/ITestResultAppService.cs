using Backend_OddityVR.Application.DTO;
using Backend_OddityVR.Domain.Model;

namespace Backend_OddityVR.Application.AppService.Interfaces
{
    public interface ITestResultAppService
    {
        public void CreateNewTestResult(CreateTestResultCmd newTestResult);
        public List<TestResult> GetAllTestResults();
        public List<User> GetAllTestUsers();
        public TestResult GetTestResultById(int id);
        public void UpdateTestResult(CreateTestResultCmd updateTestResult, int id);
        public void DeleteTestResultAsync(int id);
    }
}
