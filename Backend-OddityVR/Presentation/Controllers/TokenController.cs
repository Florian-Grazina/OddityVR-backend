using Backend_OddityVR.Application.AppService.Interfaces;
using Backend_OddityVR.Application.DTO;
using Backend_OddityVR.Application.DTO.UserDTO;
using Backend_OddityVR.Domain.Model;
using Backend_OddityVR.Domain.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend_OddityVR.Presentation.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : Controller
    {
        // properties
        private readonly IConfiguration _configuration;

        private readonly IUserAppService _userService;


        // constructor
        public TokenController(IConfiguration config, IUserAppService userService)
        {
            _configuration = config;
            _userService = userService;
        }


        // methods
        [HttpPost]
        public ActionResult Post(LoginUserDTO userLogin)
        {
            if (CmdFieldsChecker.Check(userLogin))
            {
                User user;

                try
                {
                    user = _userService.Login(userLogin);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                //create claims details based on the user information
                var claims = new[] {
                    //new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    //new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("Email", user.Email),
                    new Claim(ClaimTypes.Role, user.RoleId.ToString())
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(30),
                    signingCredentials: signIn
                    );

                var jsonToken = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new JwtDTO() {Key = jsonToken.ToString()});
                 }
            else
            {
                return BadRequest("Form is imcomplete");
            }
        }
    }
}
