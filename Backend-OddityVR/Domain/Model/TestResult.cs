namespace Backend_OddityVR.Domain.Model
{
    public class TestResult
    {
        public int Id { get; set; }
        public bool Sharing { get; set; } // if the user wants to share the result to his manager/hr
        public string Summary { get; set; }
        public int BatchId { get; set; }
        public int UserId { get; set; }
    }
}
