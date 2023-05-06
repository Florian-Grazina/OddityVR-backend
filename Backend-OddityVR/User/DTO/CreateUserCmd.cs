namespace Backend_OddityVR.User.DTO
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
                Email = this.Email,
                Password = this.Password,
                Birthdate = this.Birthdate,
                RoleId = this.RoleId,
                DepartmentId = this.DepartmentId
            };
        }
    }
}
