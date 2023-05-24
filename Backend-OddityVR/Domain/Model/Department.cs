namespace Backend_OddityVR.Domain.Model
{
    public class Department : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
    }
}
