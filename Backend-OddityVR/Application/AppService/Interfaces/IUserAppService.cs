using Backend_OddityVR.Application.DTO.UserDTO;
using Backend_OddityVR.Domain.Model;

namespace Backend_OddityVR.Application.AppService.Interfaces
{
    public interface IUserAppService
    {
        public User CreateNewUser(CreateUserCmd newUser);
        public List<User> GetAllUsers();
        public List<User> GetAllUsersFromDepartmentId(int id);
        public User GetUserById(int id);
        public User UpdateUser(UpdateUserCmd updateUser);
        public void DeleteUser(int id);
        public User Login(LoginUserDTO user);
    }
}
