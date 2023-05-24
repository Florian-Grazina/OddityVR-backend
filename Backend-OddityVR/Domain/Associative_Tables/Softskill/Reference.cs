namespace Backend_OddityVR.Domain.Associative_Tables.Softskill
{
    public class Reference
    {
        // Associative table, test that references a softskill with a value
        public int TestId { get; set; }
        public int SoftskillId { get; set; }
        public int Value { get; set; }
    }
}
