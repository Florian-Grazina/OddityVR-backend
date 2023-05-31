using Backend_OddityVR.Domain.Model;
using System.Xml.Linq;

namespace Backend_OddityVR.Application.DTO.UserDTO
{
    public class UserDetailsDTO
    {
        // properties
        public int Id { get; set; }
        public string Email { get; set; }
        public string Role{ get; set; }
        public int RoleId { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime? LastConnection { get; set; }


        // constructor
        public UserDetailsDTO() { }


        public UserDetailsDTO(User user, string role)
        {
            Id = user.Id;
            Email = user.Email;
            Role = role;
            RoleId = user.RoleId;
            Birthdate = user.Birthdate;
            LastConnection = user.LastConnection;
        }
    }
}
