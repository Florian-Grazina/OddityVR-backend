using Backend_OddityVR.Application.AppService.Interfaces;
using Backend_OddityVR.Application.DTO.UserDTO;
using Backend_OddityVR.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Backend_OddityVR.Presentation.Controllers
{
    [Route("api/user")]
    [EnableCors("Dashboard")]
    [ApiController]
    public class UserController : Controller
    {
        // properties
        private readonly IUserAppService _userService;


        // constructor
        public UserController(IUserAppService userService)
        {
            _userService = userService;
        }


        // methods
        [Route("create")]
        [HttpPost]
        public ActionResult<UserDetailsDTO> CreateNewUser(CreateUserCmd newUserCmd)
        {
            try
            {
                return Ok(_userService.CreateNewUser(newUserCmd));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("csv_script")]
        [HttpGet]
        public ActionResult<int> CsvScript()
        {
            try
            {
                return Ok(_userService.CreateUsersWithCSV());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("get_all")]
        [HttpGet]
        public ActionResult<List<User>> GetAllUser()
        {
            try
            {
                return Ok(_userService.GetAllUsers());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("get_all_from_department/{id:int}")]
        [HttpGet]
        public ActionResult<List<User>> GetAllUsersFromDepartmentId(int id)
        {
            try
            {
                return Ok(_userService.GetAllUsersFromDepartmentId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("get/{id:int}")]
        [HttpGet]
        public ActionResult<User> GetUserById(int id)
        {
            try
            {
                return Ok(_userService.GetUserById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("update")]
        [HttpPut]
        public ActionResult<UserDetailsDTO> UpdateUser(UpdateUserCmd newUserCmd)
        {
            try
            {
                return Ok(_userService.UpdateUser(newUserCmd));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("delete/{id:int}")]
        [HttpDelete]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                _userService.DeleteUser(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
