namespace Backend_OddityVR.Domain.DTO
{
    public class CreateProspeCmd
    {
        // properties
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }


        // constructor
        public CreateProspeCmd() { }


        // methods
        public Prospe ToModel()
        {
            return new Prospe
            {
                Name = Name,
                Email = Email,
                Phone = Phone,
                Subject = Subject,
                Message = Message,
                DateMessage = DateTime.Now
            };
        }
    }
}
