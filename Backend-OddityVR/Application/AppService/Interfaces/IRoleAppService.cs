using Backend_OddityVR.Application.DTO;
using Backend_OddityVR.Domain.Model;

namespace Backend_OddityVR.Application.AppService.Interfaces
{
    public interface IRoleAppService
    {
        public void CreateNewRole(CreateRoleCmd newRoleCmd);
        public List<Role> GetAllRoles();
        public Role GetRolebyId(int id);
        public void UpdateRole(CreateRoleCmd updateRoleCmd, int id);
        public void DeleteRole(int id);
    }
}
