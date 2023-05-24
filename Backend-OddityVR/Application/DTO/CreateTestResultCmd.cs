using Backend_OddityVR.Domain.Model;

namespace Backend_OddityVR.Application.DTO
{
    public class CreateTestResultCmd
    {
        // properties
        public bool Sharing { get; set; }
        public string Summary { get; set; }
        public int BatchId { get; set; }
        public int UserId { get; set; }


        // constructor
        public CreateTestResultCmd() { }


        // methods
        public TestResult ToModel(int id = 0)
        {
            return new TestResult
            {
                Id = id,
                Sharing = Sharing,
                Summary = Summary,
                BatchId = BatchId,
                UserId = UserId
            };
        }
    }
}
