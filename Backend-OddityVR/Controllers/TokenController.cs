using Backend_OddityVR.Domain.AppService;
using Backend_OddityVR.Domain.DTO.UserDTO;
using Backend_OddityVR.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend_OddityVR.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : Controller
    {
        // properties
        private IConfiguration _configuration;

        private readonly IUserAppService _userService;


        // constructor
        public TokenController(IConfiguration config, IUserAppService userService)
        {
            _configuration = config;
            _userService = userService;
        }


        // methods
        [HttpPost]
        public async Task<IActionResult> Post(LoginUserDTO userLogin)
        {
            if(CmdFieldsChecker.Check(userLogin))
            {
                User? user = _userService.Login(userLogin);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.Id.ToString()),
                        new Claim("Email", user.Email),
                        new Claim("Role", user.RoleId.ToString())
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

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest("Form is imcomplete");
            }
        }
    }
}
