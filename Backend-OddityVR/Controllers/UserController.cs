using Backend_OddityVR.Domain.AppService;
using Backend_OddityVR.Domain.DTO.UserDTO;
using Microsoft.AspNetCore.Mvc;

namespace Backend_OddityVR.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController
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
        public User CreateNewUser(CreateUserCmd newUserCmd)
        {
            return _userService.CreateNewUser(newUserCmd);
        }


        [Route("get_all")]
        [HttpGet]
        public List<User> GetAllUser()
        {
            return _userService.GetAllUsers();
        }


        [Route("get_all_from_department/{id:int}")]
        [HttpGet]
        public List<User> GetAllUsersFromDepartmentId(int id)
        {
            return _userService.GetAllUsersFromDepartmentId(id);
        }


        [Route("get/{id:int}")]
        [HttpGet]
        public User GetUserById(int id)
        {
            return _userService.GetUserById(id);
        }


        [Route("update/{id:int}")]
        [HttpPut]
        public User UpdateUser(UpdateUserCmd newUserCmd)
        {
            return _userService.UpdateUser(newUserCmd);
        }


        [Route("delete/{id:int}")]
        [HttpDelete]
        public void DeleteUser(int id)
        {
            _userService.DeleteUser(id);
        }
    }
}
