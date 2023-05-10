using System.ComponentModel.DataAnnotations;

namespace Backend_OddityVR.Domain.DTO
{
    public class CreateRoleCmd
    {
        // properties
        [Required(ErrorMessage = "Role name is mandatory")]
        public string Name { get; set; }


        // constructor
        public CreateRoleCmd() { }


        // methods
        public Role ToModel(int id = 0)
        {
            return new Role
            {
                Id = id,
                Name = Name
            };
        }
    }
}
