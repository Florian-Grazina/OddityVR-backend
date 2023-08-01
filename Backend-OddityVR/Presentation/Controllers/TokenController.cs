using Backend_OddityVR.Application.AppService.Interfaces;
using Backend_OddityVR.Application.DTO;
using Backend_OddityVR.Application.DTO.UserDTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Backend_OddityVR.Presentation.Controllers
{
    [Route("api/token")]
    [EnableCors("Dashboard")]
    [ApiController]
    public class TokenController : Controller
    {
        private readonly ITokenAppService _tokenAppService;

        
        public TokenController(ITokenAppService tokenAppService)
        {
            _tokenAppService = tokenAppService;
        }


        [HttpPost]
        public ActionResult<JwtDTO> GetToken(LoginUserDTO userLogin)
        {
            try
            {
                Console.WriteLine("test");
                return Ok(_tokenAppService.GetToken(userLogin));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
    }
}
