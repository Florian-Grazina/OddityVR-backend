using Backend_OddityVR.Domain.Model;

namespace Backend_OddityVR.Application.DTO
{
    public class CreateBatchCmd
    {
        // properties
        public DateTime CreationDate { get; set; }
        public int UserId { get; set; }


        // constructor
        public CreateBatchCmd() { }


        // methods
        public Batch ToModel(int id = 0)
        {
            return new Batch
            {
                Id = id,
                CreationDate = CreationDate,
                UserId = UserId
            };
        }
    }
}
