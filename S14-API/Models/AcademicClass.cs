namespace S14_API.Models
{
    public class AcademicClass
    {
        public int Id { get; set; }
        public required string Level { get; set; }

        public int HeadTeacherId { get; set; }
        public required Teacher HeadTeacher { get; set; }
    }
}
