using Backend_OddityVR.Domain.AppService;
using Backend_OddityVR.Domain.DTO;
using Backend_OddityVR.Model;
using Microsoft.AspNetCore.Mvc;

namespace Backend_OddityVR.Controllers
{
    [Route("api/test_result")]
    [ApiController]
    public class TestResultController
    {
        // properties
        private readonly ITestResultAppService _testResultService;


        // constructor
        public TestResultController(ITestResultAppService TestResultService)
        {
            _testResultService = TestResultService;
        }


        // methods
        [Route("create")]
        [HttpPost]
        public void CreateNewTestResult(CreateTestResultCmd newTestResultCmd)
        {
            _testResultService.CreateNewTestResult(newTestResultCmd);
        }


        [Route("get_all")]
        [HttpGet]
        public List<TestResult> GetAllTestResults()
        {
            return _testResultService.GetAllTestResults();
        }


        [Route("get/{id:int}")]
        [HttpGet]
        public TestResult GetTestResultById(int id)
        {
            return _testResultService.GetTestResultById(id);
        }


        [Route("update/{id:int}")]
        [HttpPut]
        public void UpdateTestResult(CreateTestResultCmd updateTestResultCmd, int id)
        {
            _testResultService.UpdateTestResult(updateTestResultCmd, id);
        }


        [Route("delete/{id:int}")]
        [HttpDelete]
        public void DeleteTestResult(int id)
        {
            _testResultService.DeleteTestResultAsync(id);
        }
    }
}
