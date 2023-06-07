using Backend_OddityVR.Application.AppService.Interfaces;
using Backend_OddityVR.Application.DTO;
using Backend_OddityVR.Domain.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Backend_OddityVR.Presentation.Controllers
{
    [Route("api/prospe")]
    [EnableCors("WebsiteForm")]
    [ApiController]
    public class ProspeController
    {
        // properties
        private readonly IProspeAppService _prospeService;


        // constructor
        public ProspeController(IProspeAppService prospeService)
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


        //[Route("get_all")]
        //[HttpGet]
        //public List<Prospe> GetAllProspe()
        //{
        //    return _prospeService.GetAllProspes();
        //}


        //[Route("get/{id:int}")]
        //[HttpGet]
        //public Prospe GetProspeById(int id)
        //{
        //    return _prospeService.GetProspeById(id);
        //}


        //[Route("delete/{id:int}")]
        //[HttpDelete]
        //public void DeleteProspe(int id)
        //{
        //    _prospeService.DeleteProspe(id);
        //}
    }
}
