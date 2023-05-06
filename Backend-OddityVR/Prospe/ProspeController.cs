using Microsoft.AspNetCore.Mvc;
using Backend_OddityVR.Prospe.DTO;
using Microsoft.AspNetCore.Cors;

namespace Backend_OddityVR.Prospe
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
        [HttpGet]
        public void DeleteProspe(int id)
        {
            _prospeService.DeleteProspe(id);
        }
    }
}
