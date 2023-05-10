namespace Backend_OddityVR
{
    public class Prospe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime DateMessage { get; set; }
        public DateTime? ReadDate { get; set; }
        public int? UserId { get; set; }
    }
}
