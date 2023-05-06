using Backend_OddityVR.User.DTO;
using Backend_OddityVR.User;
using Microsoft.AspNetCore.Mvc;

namespace Backend_OddityVR.User
{
    [Route("api/user")]
    [ApiController]
    public class UserController
    {
        // properties
        private readonly UserAppService _userService;


        // constructor
        public UserController(UserAppService userService)
        {
            _userService = userService;
        }


        // methods
        [Route("create")]
        [HttpPost]
        public void CreateNewUser(CreateUserCmd newUserCmd)
        {
            _userService.CreateNewUser(newUserCmd);
        }


        [Route("get_all")]
        [HttpGet]
        public List<User> GetAllUser()
        {
            return _userService.GetAllUsers();
        }


        [Route("get/{id:int}")]
        [HttpGet]
        public User GetUserById(int id)
        {
            return _userService.GetUserById(id);
        }


        [Route("update/{id:int}")]
        [HttpPost]
        public void UpdateUser(CreateUserCmd newUserCmd, int id)
        {
            _userService.UpdateUser(newUserCmd, id);
        }


        [Route("delete/{id:int}")]
        [HttpGet]
        public void DeleteUser(int id)
        {
            _userService.DeleteUser(id);
        }
    }
}
