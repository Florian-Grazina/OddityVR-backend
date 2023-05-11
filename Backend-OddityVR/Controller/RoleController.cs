using Backend_OddityVR.Domain.AppService;
using Backend_OddityVR.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Backend_OddityVR.Controller
{
    [Route("api/role")]
    [ApiController]
    public class RoleController
    {
        // properties
        private readonly IRoleAppService _roleService;


        // constructor
        public RoleController(IRoleAppService roleService)
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
        [HttpPut]
        public void UpdateRole([FromBody] CreateRoleCmd updateRoleCmd, int id)
        {
            _roleService.UpdateRole(updateRoleCmd, id);
        }


        [Route("delete/{id:int}")]
        [HttpDelete]
        public void DeleteRole(int id)
        {
            _roleService.DeleteRole(id);
        }
    }
}
