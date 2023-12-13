namespace S14_API.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public int TeacherId { get; set; }
        public required Teacher Teacher { get; set; }
    }

}
