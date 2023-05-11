using Backend_OddityVR.Domain.DTO;

namespace Backend_OddityVR.Domain.AppService
{
    public interface IUserAppService
    {
        public void CreateNewUser(CreateUserCmd newUser);
        public List<User> GetAllUsers();
        public User GetUserById(int id);
        public void UpdateUser(CreateUserCmd updateUser, int id);
        public void DeleteUser(int id);
    }
}
