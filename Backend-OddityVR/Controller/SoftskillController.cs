using Backend_OddityVR.Domain.AppService;
using Backend_OddityVR.Domain.DTO;
using Backend_OddityVR.Model;
using Microsoft.AspNetCore.Mvc;

namespace Backend_OddityVR.Controller
{
    [Route("api/softskill")]
    [ApiController]
    public class SoftskillController
    {
        // properties
        private readonly SoftskillAppService _softskillService;


        // constructor
        public SoftskillController(SoftskillAppService softskillService)
        {
            _softskillService = softskillService;
        }


        // methods
        [Route("create")]
        [HttpPost]
        public void CreateNewSoftskill(CreateSoftskillCmd newSoftskillCmd)
        {
            _softskillService.CreateNewSoftskill(newSoftskillCmd);
        }


        [Route("get_all")]
        [HttpGet]
        public List<Softskill> GetAllSoftskills()
        {
            return _softskillService.GetAllSoftskills();
        }


        [Route("get/{id:int}")]
        [HttpGet]
        public Softskill GetSoftskillById(int id)
        {
            return _softskillService.GetSoftskillById(id);
        }


        [Route("update/{id:int}")]
        [HttpPut]
        public void UpdateSoftskill(CreateSoftskillCmd newSoftskillCmd, int id)
        {
            _softskillService.UpdateSoftskill(newSoftskillCmd, id);
        }


        [Route("delete/{id:int}")]
        [HttpDelete]
        public void DeleteSoftskill(int id)
        {
            _softskillService.DeleteSoftskill(id);
        }
    }
}
