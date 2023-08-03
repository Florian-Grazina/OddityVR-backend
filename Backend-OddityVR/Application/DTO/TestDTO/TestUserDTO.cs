using Backend_OddityVR.Domain.Model;

namespace Backend_OddityVR.Application.DTO.TestDTO
{
    public class TestUserDTO
    {
        // properties
        public int Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }


        // constructor
        public TestUserDTO() { }

    }
}
