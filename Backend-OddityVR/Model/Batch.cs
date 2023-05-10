namespace Backend_OddityVR.Model
{
    public class Batch
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int UserId { get; set; } // User that has access to the whole batch (team manager)
    }
}
