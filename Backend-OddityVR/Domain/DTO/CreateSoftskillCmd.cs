using Backend_OddityVR.Model;

namespace Backend_OddityVR.Domain.DTO
{
    public class CreateSoftskillCmd
    {
        // properties
        public string Name { get; set; }


        // constructor
        public CreateSoftskillCmd() { }


        // methods
        public Softskill ToModel(int id = 0)
        {
            return new Softskill
            {
                Id = id,
                Name = Name
            };
        }
    }
}
