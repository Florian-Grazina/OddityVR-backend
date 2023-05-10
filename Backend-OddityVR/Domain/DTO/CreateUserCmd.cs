namespace Backend_OddityVR.Domain.DTO
{
    public class CreateUserCmd
    {
        // properties
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
        public int RoleId { get; set; }
        public int DepartmentId { get; set; }


        // constructor
        public CreateUserCmd() { }


        // method
        public User ToModel(int id = 0)
        {
            return new User
            {
                Email = Email,
                Password = Password,
                Birthdate = Birthdate,
                RoleId = RoleId,
                DepartmentId = DepartmentId
            };
        }
    }
}
