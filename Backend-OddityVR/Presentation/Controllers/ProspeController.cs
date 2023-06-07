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
    public class ProspeController : Controller
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
        public ActionResult CreateNewProspe(CreateProspeCmd newProspeCmd)
        {
            try 
            {
                _prospeService.CreateNewProspe(newProspeCmd);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
