using Backend_OddityVR.Application.DTO;
using Backend_OddityVR.Application.DTO.UserDTO;

namespace Backend_OddityVR.Application.AppService.Interfaces
{
    public interface ITokenAppService
    {
        public JwtDTO GetToken(LoginUserDTO userLogin);
    }
}
