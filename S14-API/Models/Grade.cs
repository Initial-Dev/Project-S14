namespace S14_API.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public int Value { get; set; }

        public int StudentId { get; set; }
        public required Student Student { get; set; }

        public int TeacherId { get; set; }
        public required Teacher Teacher { get; set; }
        public DateTime Date { get; set; }
    }

}
