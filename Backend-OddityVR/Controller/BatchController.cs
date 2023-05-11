using Backend_OddityVR.Domain.AppService;
using Backend_OddityVR.Domain.DTO;
using Backend_OddityVR.Model;   
using Microsoft.AspNetCore.Mvc;

namespace Backend_OddityVR.Controller
{
    [Route("api/batch")]
    [ApiController]
    public class BatchController
    {
        // properties
        private readonly IBatchAppService _batchService;


        // constructor
        public BatchController(IBatchAppService batchService)
        {
            _batchService = batchService;
        }


        // methods
        [Route("create")]
        [HttpPost]
        public void CreateNewBatch(CreateBatchCmd newBatchCmd)
        {
            _batchService.CreateNewBatch(newBatchCmd);
        }


        [Route("get_all")]
        [HttpGet]
        public List<Batch> GetAllBatches()
        {
            return _batchService.GetAllBatches();
        }


        [Route("get/{id:int}")]
        [HttpGet]
        public Batch GetBatchById(int id)
        {
            return _batchService.GetBatchById(id);
        }


        [Route("update/{id:int}")]
        [HttpPut]
        public void UpdateBatch(CreateBatchCmd updateBatchCmd, int id)
        {
            _batchService.UpdateBatch(updateBatchCmd, id);
        }


        [Route("delete/{id:int}")]
        [HttpDelete]
        public void DeleteBatch(int id)
        {
            _batchService.DeleteBatch(id);
        }
    }
}
