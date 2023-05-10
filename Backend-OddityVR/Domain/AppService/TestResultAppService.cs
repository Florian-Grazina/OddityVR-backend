﻿using Backend_OddityVR.Domain.DTO;
using Backend_OddityVR.Domain.Repo;
using Backend_OddityVR.Model;

namespace Backend_OddityVR.Domain.AppService
{
    public class TestResultAppService
    {
        // properties
        private readonly TestResultRepo _testResultRepo;


        // constructor
        public TestResultAppService()
        {
            _testResultRepo = new();
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


        // get id
        public TestResult GetTestResultById(int id)
        {
            return _testResultRepo.GetTestResultById(id);
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
