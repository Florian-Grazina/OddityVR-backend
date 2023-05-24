namespace Backend_OddityVR.Domain.Model
{
    public class User : IModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime? LastConnection { get; set; }
        public int RoleId { get; set; }
        public int DepartmentId { get; set; }
    }
}
