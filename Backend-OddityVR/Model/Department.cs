using Backend_OddityVR.Model;

namespace Backend_OddityVR
{
    public class Department : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
    }
}
