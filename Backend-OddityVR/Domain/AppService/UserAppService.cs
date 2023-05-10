using Backend_OddityVR.Domain.DTO;
using Backend_OddityVR.Domain.Repo;

namespace Backend_OddityVR.Domain.AppService
{
    public class UserAppService
    {
        // properties
        private readonly UserRepo _userRepo;


        // constructor
        public UserAppService()
        {
            _userRepo = new();
        }


        // create
        public void CreateNewUser(CreateUserCmd newUser)
        {
            User user = newUser.ToModel();
            _userRepo.CreateNewUser(user);
        }


        // get all
        public List<User> GetAllUsers()
        {
            return _userRepo.GetAllUser();
        }


        // get id
        public User GetUserById(int id)
        {
            return _userRepo.GetUserById(id);
        }


        // update
        public void UpdateUser(CreateUserCmd updateUser, int id)
        {
            User user = updateUser.ToModel(id);
            _userRepo.UpdateUser(user);
        }


        // delete
        public void DeleteUser(int id)
        {
            _userRepo.DeleteUser(id);
        }
    }
}
