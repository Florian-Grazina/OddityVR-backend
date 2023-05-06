using Backend_OddityVR.Role.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Backend_OddityVR.Role
{
    [Route("api/role")]
    [ApiController]
    public class RoleController
    {
        // properties
        private readonly RoleAppService _roleService;


        // constructor
        public RoleController(RoleAppService roleService)
        {
            _roleService = roleService;
        }


        // methods
        [Route("create")]
        [HttpPost]
        public void CreateNewRole(CreateRoleCmd newRoleCmd)
        {
            _roleService.CreateNewRole(newRoleCmd);
        }


        [Route("get_all")]
        [HttpGet]
        public List<Role> GetAllRole()
        {
            return _roleService.GetAllRoles();
        }


        [Route("get/{id:int}")]
        [HttpGet]
        public Role GetRole(int id)
        {
            return _roleService.GetRolebyId(id);
        }


        [Route("update/{id:int}")]
        [HttpPost]
        public void UpdateRole([FromBody] CreateRoleCmd updateRoleCmd, int id)
        {
            _roleService.UpdateRole(updateRoleCmd, id);
        }


        [Route("delete/{id:int}")]
        [HttpGet]
        public void DeleteRole(int id)
        {
            _roleService.DeleteRole(id);
        }
    }
}
