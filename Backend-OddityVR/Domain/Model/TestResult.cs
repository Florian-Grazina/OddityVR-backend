namespace Backend_OddityVR.Domain.Model
{
    public class TestResult : IModel
    {
        public int Id { get; set; }
        public bool Sharing { get; set; }
        public string Summary { get; set; }
        public int BatchId { get; set; }
        public int UserId { get; set; }
    }
}
