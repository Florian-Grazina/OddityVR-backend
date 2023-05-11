using Backend_OddityVR.Domain.AppService;
using Backend_OddityVR.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Backend_OddityVR.Controller
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
        [HttpPut]
        public void UpdateUser(CreateUserCmd newUserCmd, int id)
        {
            _userService.UpdateUser(newUserCmd, id);
        }


        [Route("delete/{id:int}")]
        [HttpDelete]
        public void DeleteUser(int id)
        {
            _userService.DeleteUser(id);
        }
    }
}
