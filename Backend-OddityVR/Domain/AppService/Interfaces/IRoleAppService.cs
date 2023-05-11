using Backend_OddityVR.Domain.DTO;

namespace Backend_OddityVR.Domain.AppService
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
