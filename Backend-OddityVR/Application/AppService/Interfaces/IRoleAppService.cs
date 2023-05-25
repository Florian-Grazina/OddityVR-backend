using Backend_OddityVR.Application.DTO.RoleDTO;
using Backend_OddityVR.Domain.Model;

namespace Backend_OddityVR.Application.AppService.Interfaces
{
    public interface IRoleAppService
    {
        public void CreateNewRole(CreateRoleCmd newRoleCmd);
        public List<Role> GetAllRoles();
        public List<Role> GetClientRoles();
        public Role GetRolebyId(int id);
        public void UpdateRole(CreateRoleCmd updateRoleCmd, int id);
        public void DeleteRole(int id);
    }
}
