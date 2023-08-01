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
        public int NumberOfTests { get; set; }


        // constructor
        public TestUserDTO() { }
    }
}
