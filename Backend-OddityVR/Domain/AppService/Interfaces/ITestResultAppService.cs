using Backend_OddityVR.Domain.DTO;
using Backend_OddityVR.Model;

namespace Backend_OddityVR.Domain.AppService
{
    public interface ITestResultAppService
    {
        public void CreateNewTestResult(CreateTestResultCmd newTestResult);
        public List<TestResult> GetAllTestResults();
        public TestResult GetTestResultById(int id);
        public void UpdateTestResult(CreateTestResultCmd updateTestResult, int id);
        public void DeleteTestResultAsync(int id);
    }
}
