using Backend_OddityVR.Application.AppService.Interfaces;
using Backend_OddityVR.Application.DTO.RoleDTO;
using Backend_OddityVR.Domain.Model;
using Backend_OddityVR.Infrastructure.Repo;

namespace Backend_OddityVR.Application.AppService
{
    public class RoleAppService : IRoleAppService
    {
        // properties
        private readonly RoleRepo _roleRepo;


        // constructor
        public RoleAppService(RoleRepo roleRepo)
        {
            _roleRepo = roleRepo;
        }


        // create
        public void CreateNewRole(CreateRoleCmd newRoleCmd)
        {
            // TODO Check les champs entrés

            Role role = newRoleCmd.ToModel();
            _roleRepo.CreateNewRole(role);
        }


        // get all
        public List<Role> GetAllRoles()
        {
            return _roleRepo.GetAllRoles();
        }

        public List<Role> GetClientRoles()
        {
            return GetAllRoles().Where(role => role.Id <= 4).ToList();
        }


        // get id
        public Role GetRolebyId(int id)
        {
            return _roleRepo.GetRoleById(id);
        }


        // update
        public void UpdateRole(CreateRoleCmd updateRoleCmd, int id)
        {
            // TODO Ceck les champs entrés

            Role role = updateRoleCmd.ToModel(id);
            _roleRepo.UpdateRole(role);
        }


        // delete
        public void DeleteRole(int id)
        {
            _roleRepo.DeleteRole(id);
        }
    }
}
