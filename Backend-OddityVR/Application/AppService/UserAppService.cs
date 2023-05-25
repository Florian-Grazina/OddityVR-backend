using Backend_OddityVR.Application.AppService.Interfaces;
using Backend_OddityVR.Application.DTO.UserDTO;
using Backend_OddityVR.Domain.Model;
using Backend_OddityVR.Domain.Service;
using Backend_OddityVR.Infrastructure.Repo;

namespace Backend_OddityVR.Application.AppService
{
    public class UserAppService : IUserAppService
    {
        // properties
        private readonly UserRepo _userRepo;
        public readonly RoleRepo _roleRepo;


        // constructor
        public UserAppService(UserRepo userRepo, RoleRepo roleRepo)
        {
            _userRepo = userRepo;
            _roleRepo = roleRepo;
        }


        // create
        public UserDetailsDTO CreateNewUser(CreateUserCmd newUser)
        {
            if (CmdFieldsChecker.Check(newUser))
            {
                User user = _userRepo.CreateNewUser((User)newUser.ToModel());
                return GetUserById(user.Id);
            }
            else throw new Exception("Cmd is not complete");
        }


        // get all
        public List<User> GetAllUsers()
        {
            return _userRepo.GetAllUser();
        }


        public List<UserDetailsDTO> GetAllUsersFromDepartmentId(int id)
        {
            List<User> users = _userRepo.GetAllUsersFromDepartmentId(id);
            List<Role> roles = _roleRepo.GetAllRoles();
            List<UserDetailsDTO> usersToReturn = new();

            foreach (User user in users)
            {
                Role role = roles.Where(role => role.Id == user.RoleId).ToList().First();

                usersToReturn.Add(new UserDetailsDTO(user, role.Name));
            }
            return usersToReturn;
        }


        // get id
        public UserDetailsDTO GetUserById(int id)
        {
            User user = _userRepo.GetUserById(id);
            Role role = _roleRepo.GetRoleById(user.RoleId);

            return new UserDetailsDTO(user, role.Name);
        }


        // update
        public UserDetailsDTO UpdateUser(UpdateUserCmd updateUser)
        {
            if(CmdFieldsChecker.Check(updateUser))
            {
                if(_userRepo.GetUserById(updateUser.Id) != null)
                {
                    User user = (User)updateUser.ToModel();
                    _userRepo.UpdateUser(user);
                    return GetUserById(user.Id);
                }
                else throw new Exception("User doesn't exist");
            }
            else throw new Exception("Cmd is not complete");
        }


        // delete
        public void DeleteUser(int id)
        {
            if (_userRepo.GetUserById(id) != null)
            {
                _userRepo.DeleteUser(id);
            }
            else
                throw new Exception("User doesn't exist");
        }


        // Login
        public User? Login(LoginUserDTO loginUser)
        {
            return _userRepo.Login((User)loginUser.ToModel());
        }
    }
}
