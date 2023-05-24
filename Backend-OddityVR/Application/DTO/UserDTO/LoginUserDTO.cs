using Backend_OddityVR.Domain.Model;

namespace Backend_OddityVR.Application.DTO.UserDTO
{
    public class LoginUserDTO : ICmdAndDTO
    {
        // properties
        public string Email { get; set; }
        public string Password { get; set; }


        // constructor
        public LoginUserDTO() { }


        // methods
        public IModel ToModel()
        {
            return new User()
            {
                Email = Email,
                Password = Password
            };
        }
    }
}
