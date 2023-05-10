using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Backend_OddityVR.Domain.AppService;
using Backend_OddityVR.Domain.DTO;

namespace Backend_OddityVR.Controller
{
    [Route("api/prospe")]
    [EnableCors]
    [ApiController]
    public class ProspeController
    {
        // properties
        private readonly ProspeAppService _prospeService;


        // constructor
        public ProspeController(ProspeAppService prospeService)
        {
            _prospeService = prospeService;
        }


        // methods
        [Route("create")]
        [HttpPost]
        public void CreateNewProspe(CreateProspeCmd newProspeCmd)
        {
            _prospeService.CreateNewProspe(newProspeCmd);
        }


        [Route("get_all")]
        [HttpGet]
        public List<Prospe> GetAllProspe()
        {
            return _prospeService.GetAllProspes();
        }


        [Route("get/{id:int}")]
        [HttpGet]
        public Prospe GetProspeById(int id)
        {
            return _prospeService.GetProspeById(id);
        }


        [Route("delete/{id:int}")]
        [HttpDelete]
        public void DeleteProspe(int id)
        {
            _prospeService.DeleteProspe(id);
        }
    }
}
