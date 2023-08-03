using Backend_OddityVR.Application.AppService.Interfaces;
using Backend_OddityVR.Application.DTO;
using Backend_OddityVR.Application.DTO.TestDTO;
using Backend_OddityVR.Domain.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace Backend_OddityVR.Presentation.Controllers
{
    [Route("api/test_result")]
    [EnableCors("Dashboard")]
    [ApiController]
    public class TestResultController : Controller
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

        [Route("get_all_user")]
        [HttpGet]
        public ActionResult<List<TestUserDTO>> GetAllTestUser()
        {
            try
            {
                return Ok(_testResultService.GetAllTestUsers());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("get_user/{id:int}")]
        [HttpGet]
        public ActionResult<List<TestUserDTO>> GetTestUser(int id)
        {
            try
            {
                return Ok(_testResultService.GetTestUserById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
