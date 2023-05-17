using Backend_OddityVR.Model;

namespace Backend_OddityVR.Domain.DTO.UserDTO
{
    public class UpdateUserCmd : ICmdAndDTO
    {
        // properties
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
        public int RoleId { get; set; }
        public int DepartmentId { get; set; }


        // constructor
        public UpdateUserCmd() { }


        // method
        public IModel ToModel()
        {
            return new User
            {
                Id = Id,
                Email = Email,
                Password = Password,
                Birthdate = Birthdate,
                RoleId = RoleId,
                DepartmentId = DepartmentId
            };
        }
    }
}
