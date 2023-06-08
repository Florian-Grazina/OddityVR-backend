using Backend_OddityVR.Application.DTO.UserDTO;
using Backend_OddityVR.Domain.Model;

namespace Backend_OddityVR.Application.AppService.Interfaces
{
    public interface IUserAppService
    {
        public UserDetailsDTO CreateNewUser(CreateUserCmd newUser);
        public int CreateUsersWithCSV();
        public List<User> GetAllUsers();
        public List<UserDetailsDTO> GetAllUsersFromDepartmentId(int id);
        public UserDetailsDTO GetUserById(int id);
        public UserDetailsDTO UpdateUser(UpdateUserCmd updateUser);
        public void DeleteUser(int id);
        public User Login(LoginUserDTO user);
    }
}
