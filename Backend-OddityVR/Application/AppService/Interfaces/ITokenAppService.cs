using Backend_OddityVR.Application.DTO;
using Backend_OddityVR.Application.DTO.UserDTO;
using Backend_OddityVR.Domain.Model;

namespace Backend_OddityVR.Application.AppService.Interfaces
{
    public interface ITokenAppService
    {
        public User GetUser(LoginUserDTO loginUserDTO);
        public JwtDTO GetToken(LoginUserDTO loginUserDTO);
    }
}
