using Backend_OddityVR.Domain.DTO.UserDTO;
using Backend_OddityVR.Domain.Repo;
using Backend_OddityVR.Service;

namespace Backend_OddityVR.Domain.AppService
{
    public class UserAppService : IUserAppService
    {
        // properties
        private readonly UserRepo _userRepo;


        // constructor
        public UserAppService(UserRepo userRepo)
        {
            _userRepo = userRepo;
        }


        // create
        public User CreateNewUser(CreateUserCmd newUser)
        {
            try
            {
                CmdFieldsChecker.Check(newUser);
                User user = (User) newUser.ToModel();
                _userRepo.CreateNewUser(user);
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new User();
        }


        // get all
        public List<User> GetAllUsers()
        {
            return _userRepo.GetAllUser();
        }


        public List<User> GetAllUsersFromDepartmentId(int id)
        {
            return _userRepo.GetAllUsersFromDepartmentId(id);
        }


        // get id
        public User GetUserById(int id)
        {
            return _userRepo.GetUserById(id);
        }


        // update
        public User UpdateUser(UpdateUserCmd updateUser)
        {
            try
            {
                CmdFieldsChecker.Check(updateUser);
                User user = (User) updateUser.ToModel();
                _userRepo.UpdateUser(user);
                return user;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new User();
        }


        // delete
        public void DeleteUser(int id)
        {
            _userRepo.DeleteUser(id);
        }


        // Login
        public User? Login(LoginUserDTO loginUser)
        {
            return _userRepo.Login((User) loginUser.ToModel());
        }
    }
}
