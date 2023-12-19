using System.Text.Json.Serialization;

namespace S14_BlazorUI.Models
{
    public class AcademicClass
    {
        public int Id { get; set; }
        public string Level { get; set; }
        public int HeadTeacherId { get; set; }
        public Teacher HeadTeacher { get; set; }

        public StudentWrapper Students { get; set; }

    }

    public class StudentWrapper
    {
        [JsonPropertyName("$values")]
        public List<Student> Students { get; set; }
    }

}
